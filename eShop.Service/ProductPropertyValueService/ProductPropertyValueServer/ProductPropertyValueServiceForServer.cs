using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer;
using eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyValueService.ProductPropertyValueServer
{
	public class ProductPropertyValueServiceForServer : IProductPropertyValueServiceForServer
	{
		#region متد های پیکربندی اطلاعات مقادیر محصولات یا کالاها در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public ProductPropertyValueServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش تمام مقادیر محصولات یا کالاها سایت در سمت سرور یا مدیرسایت

		public List<GetProductPropertyValuesViewModel> GetProductPropertyValues()
		{
			return (from ppv in _context.TBL_ProductPropertyValues
					join ppn in _context.TBL_ProductPropertyNames on ppv.PropertyNameId equals ppn.Id

					select new GetProductPropertyValuesViewModel
					{
						PropertyNameTitle = ppn.Title,
						PropertyValueId = ppv.Id,
						Value = ppv.Value
					})
					.AsNoTracking()
					.ToList();
		}
		#endregion

		#region متد عملیاتی ثبت مقادیر ویژه گی های محصولات یا کالاهای سایت

		public OperationResult<int> CreateProductPropertyValue(CreateProductPropertyValueViewModel propertyValue)
		{
			bool Exist = ExistProductPropertyValue(0, propertyValue.PropertyNameId, propertyValue.Value);
			if (Exist)
			{
				return new OperationResult<int>
				{
					Data = propertyValue.PropertyNameId,
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			TBL_ProductPropertyValue ValueNewData = new TBL_ProductPropertyValue()
			{
				CreationDate = DateTime.Now,
				PropertyNameId = propertyValue.PropertyNameId,
				Value = propertyValue.Value,
			};

			_context.TBL_ProductPropertyValues.Add(ValueNewData);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Data = ValueNewData.Id,
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region متد عملیاتی به همراه کلیه شرط های موجود جهت ثبت یا حذف ویژه گی برای محصولات یا کالاهای ثبت شده
		public OperationResult AddOrRemoveProductPropertyForProduct(AddOrUpdateProductPropertyValueForProductViewModel addOrUpdateProperty)
		{
			List<TBL_ProductProperty> NewPropertyForProduct = new List<TBL_ProductProperty>();
			List<TBL_ProductPropertyValue> UpdateValue = new List<TBL_ProductPropertyValue>();
			List<TBL_ProductProperty> RemovePropertyForProduct = new List<TBL_ProductProperty>();
			List<TBL_ProductPropertyValue> RemovePropertyValue = new List<TBL_ProductPropertyValue>();

			var old_value = oldProductPropertyValueForProduct(addOrUpdateProperty.ProductId);

			for (int i = 0; i < addOrUpdateProperty.nameid.Count(); i++)
			{
				int type = getNameByIdForAddProduct(addOrUpdateProperty.nameid[i]).type;

				if (type == PropertyType.Single_Choice || type == PropertyType.Multiple_Choice)
				{
					if (String.IsNullOrEmpty(addOrUpdateProperty.value[i]) == false)
					{
						int ValueId = int.Parse(addOrUpdateProperty.value[i]);
						if (ValueId > 0)
						{
							bool ExistValueForPropName =
								CheckValueForPropertyName(addOrUpdateProperty.nameid[i], ValueId).Data;

							bool ExistPropNameForCategory =
								CheckPropertyNameForCategory(addOrUpdateProperty.nameid[i], addOrUpdateProperty.categoryid).Data;

							if (ExistValueForPropName && ExistPropNameForCategory)
							{
								if (old_value.Any(x => x.ValueId == ValueId) == false)
								{
									NewPropertyForProduct.Add(new TBL_ProductProperty
									{
										CreationDate = DateTime.Now,
										ProductId = addOrUpdateProperty.ProductId,
										PropertyValueId = ValueId,
									});

								}
							}
						}
					}
				}
				else if (type == PropertyType.Linear || type == PropertyType.Written)
				{
					var FindOldValue = old_value
						.Where(x => x.NameId == addOrUpdateProperty.nameid[i])
						.FirstOrDefault();

					if (FindOldValue != null)
					{
						if (String.IsNullOrEmpty(addOrUpdateProperty.value[i]) == false)
						{
							UpdateValue.Add(new TBL_ProductPropertyValue
							{
								Id = FindOldValue.ValueId,
								CreationDate = FindOldValue.CreationDate,
								LastModified = DateTime.Now,
								PropertyNameId = addOrUpdateProperty.nameid[i],
								Value = addOrUpdateProperty.value[i]

							});
						}
						else
						{
							RemovePropertyForProduct.Add(
								new TBL_ProductProperty
								{
									Id = FindOldValue.ProductPropertyId
								});

							RemovePropertyValue.Add(new TBL_ProductPropertyValue
							{
								Id = FindOldValue.ValueId,
							});

						}
					}
					else
					{
						if (String.IsNullOrEmpty(addOrUpdateProperty.value[i]) == false)
						{
							CreateProductPropertyValueViewModel NewPropertyValue = new CreateProductPropertyValueViewModel()
							{
								PropertyNameId = addOrUpdateProperty.nameid[i],
								Value = addOrUpdateProperty.value[i],

							};
							var PropertyValueId = CreateProductPropertyValue(NewPropertyValue);
							if (PropertyValueId.Data > 0)
							{
								NewPropertyForProduct.Add(new TBL_ProductProperty
								{
									CreationDate = DateTime.Now,
									ProductId = addOrUpdateProperty.ProductId,
									PropertyValueId = PropertyValueId.Data,
								});
							}
						}
					}

					old_value.Remove(FindOldValue);
				}

			}


			var level_1 = addOrUpdateProperty.value.Select(x => int.TryParse(x, out int result));
			var level_2 = addOrUpdateProperty.value.Select(x => int.TryParse(x, out int result) ? result : (int?)null);
			var level_3 = addOrUpdateProperty.value.Select(x => int.TryParse(x, out int result) ? result : (int?)null).Where(x => x.HasValue);
			var level_4 = addOrUpdateProperty.value.Select(x => int.TryParse(x, out int result) ? result : (int?)null)
				.Where(x => x.HasValue).Select(x => x.Value);

			List<int> num_1 = new List<int>()
			{
				1,2,3,4
			};

			List<int> num_2 = new List<int>()
			{
				1,2,3,4,5
			};
			var t = num_2.Except(num_1).ToList();

			level_4 = old_value.Select(x => x.ValueId).ToList()
						.Except(level_4).ToList();

			foreach (var level in level_4)
			{

				RemovePropertyForProduct.Add(new TBL_ProductProperty
				{
					Id = old_value.Where(x => x.ValueId == level)
					.FirstOrDefault().ProductPropertyId
				});
			}

			if (RemovePropertyForProduct.Count() > 0)
				_context.TBL_ProductProperties.RemoveRange(RemovePropertyForProduct);

			if (RemovePropertyValue.Count() > 0)
				_context.TBL_ProductPropertyValues.RemoveRange(RemovePropertyValue);

			if (NewPropertyForProduct.Count() > 0)
				_context.TBL_ProductProperties.AddRange(NewPropertyForProduct);

			if (UpdateValue.Count() > 0)
				_context.TBL_ProductPropertyValues.UpdateRange(UpdateValue);

			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update
			};
		}
		#endregion

		#region جهت ثبت برای کالا یا محصولات ID متد دریافت نام ویژه گی محصول بر اساس 

		public GetProductPropertyNameByIdForAddProductViewModel getNameByIdForAddProduct(int PropertyNameId)
		{
			return _context.TBL_ProductPropertyNames
							.Where(x => x.Id == PropertyNameId)
							.Select(x => new GetProductPropertyNameByIdForAddProductViewModel
							{
								NameId = x.Id,
								type = x.type,
							})
							.AsNoTracking()
							.SingleOrDefault();
		}
		#endregion

		#region متد ثبت نام ویژه گی برای محصولات یا کالاها
		public List<AddProductPropertyNameForProductViewModel> GetProductPropertyNameForProductByCategoryId(int CategoryId)
		{
			var propertyName = (from pc in _context.TBL_ProductPropertyNameCategories
								join pn in _context.TBL_ProductPropertyNames on pc.PropertyNameId equals pn.Id

								where (pc.CategoryId == CategoryId)

								select new AddProductPropertyNameForProductViewModel
								{
									NameId = pn.Id,
									PropertyNameTitle = pn.Title,
									type = pn.type,
								})
								.AsNoTracking()
								.ToList();

			for (int i = 0; i < propertyName.Count(); i++)
			{
				if (propertyName[i].type == PropertyType.Single_Choice ||
					propertyName[i].type == PropertyType.Multiple_Choice)
				{
					propertyName[i].Values = _context.TBL_ProductPropertyValues
						.Where(x => x.PropertyNameId == propertyName[i].NameId)
						.Select(x => new GetProductPropertyValuesForPropertyNameViewModel
						{
							NameId = x.PropertyNameId,
							Value = x.Value,
							ValueId = x.Id,
						})
						.AsNoTracking()
						.ToList();
				}
			}

			return propertyName;
		}
		#endregion

		#region متد لیست مقادیر ویژه گی های قدیمی برای کالاها یا محصولات

		public List<ProductPropertyOldValueForProductViewModel> oldProductPropertyValueForProduct(int ProductId)
		{
			var OldValue = (from pProperty in _context.TBL_ProductProperties
							join pv in _context.TBL_ProductPropertyValues on pProperty.PropertyValueId equals pv.Id
							join pn in _context.TBL_ProductPropertyNames on pv.PropertyNameId equals pn.Id

							where (pProperty.ProductId == ProductId)

							select new ProductPropertyOldValueForProductViewModel
							{
								NameId = pn.Id,
								Value = pv.Value,
								ValueId = pv.Id,
								ProductPropertyId = pProperty.Id,
							})
							.AsNoTracking()
							.ToList();
			return OldValue;
		}
		#endregion

		#region متد موجود بودن مقدار ویژه گی در سمت سرور
		public bool ExistProductPropertyValue(int PropertyValueId, int PropertyNameId, string PropertyValue)
		{
			return _context.TBL_ProductPropertyValues.Any(x => x.Value == PropertyValue.ToLower().Trim() &&
			x.PropertyNameId == PropertyNameId && x.Id != PropertyValueId);
		}
		#endregion

		#region متد بررسی مقدار برای نام ویژه گی

		public OperationResult<bool> CheckValueForPropertyName(int PropertyNameId, int PropertyValueId)
		{
			bool ExistValue = _context.TBL_ProductPropertyValues
				.Any(x => x.PropertyNameId == PropertyNameId && x.Id == PropertyValueId);

			return new OperationResult<bool>
			{
				Data = ExistValue,
			};
		}
		#endregion

		#region متد بررسی نام ویژه گی برای دسته بندی

		public OperationResult<bool> CheckPropertyNameForCategory(int PropertyNameId, int CategoryId)
		{
			bool ExistPropName = _context.TBL_ProductPropertyNameCategories
				.Any(x => x.PropertyNameId == PropertyNameId && x.CategoryId == CategoryId);

			return new OperationResult<bool>
			{
				Data = ExistPropName
			};
		}
		#endregion

		//=====================
		// در جدول مربوطه Title متد های بروزرسانی مقدار یا عنوان 

		#region ID متد جستجوی موجود بودن اطلاعات ویژه گی های کالاها یا محصولات بر اساس 

		public TBL_ProductPropertyValue FindProductPropertyValuesTitleById(int PropertyValuesTitleId)
		{
			return _context.TBL_ProductPropertyValues
				.Where(x => x.Id == PropertyValuesTitleId)
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion

		#region مقادیر Title متد بروزرسانی عنوان 

		public UpdateProductPropertyValueTitleViewModel FindProductPropertyValuesByIdForUpdate(int ValueTitleId)
		{
			return _context.TBL_ProductPropertyValues
				.Where(p => p.Id == ValueTitleId)
				.Select(p => new UpdateProductPropertyValueTitleViewModel
				{
					PropertyValueTitleId = p.Id,
					PropertyValueTitle = p.Value,
				})
				.SingleOrDefault();
		}
		#endregion

		#region مقادیر Title متد عملیاتی جهت بروزرسانی عنوان

		public OperationResult UpdateProductPropertyValueTitle(UpdateProductPropertyValueTitleViewModel UpdateValueTitle)
		{
			var FindPPVT = FindProductPropertyValuesTitleById(UpdateValueTitle.PropertyValueTitleId);

			if (FindPPVT == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool existPPVT = ExistPPVT(UpdateValueTitle.PropertyValueTitle, UpdateValueTitle.PropertyValueTitleId);
			if (existPPVT)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			FindPPVT.Value = UpdateValueTitle.PropertyValueTitle;
			FindPPVT.LastModified = DateTime.Now;

			_context.TBL_ProductPropertyValues.Update(FindPPVT);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}
		#endregion

		#region متد موجود بودن نام ویژه گی های کالاها یا محصولات و عملیات بر روی آن
		public bool ExistPPVT(string titlePropertyValue, int titlePropertyValueId)
		{
			return _context.TBL_ProductPropertyValues.Any(x => x.Value == titlePropertyValue.Trim().ToLower() && x.Id != titlePropertyValueId);
		}
		#endregion

		//=====================
	}
}
