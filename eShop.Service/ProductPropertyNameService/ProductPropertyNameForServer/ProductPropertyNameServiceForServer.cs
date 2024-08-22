using eShop.Common.Operations;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyNameService.ProductPropertyNameForServer
{
	public class ProductPropertyNameServiceForServer : IProductPropertyNameServiceForServer
	{
		#region متد های پیکربندی اطلاعات نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public ProductPropertyNameServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد لیست دریافت نام ویژه گی های کالاها یا محصولات

		public List<GetProductPropertyNamesViewModel> GetProductPropertyNames()
		{
			return (from n in _context.TBL_ProductPropertyNames
					join g in _context.TBL_ProductPropertyGroups on n.GroupId equals g.Id
					select new GetProductPropertyNamesViewModel
					{
						GroupTitle = g.Title,
						PropertyNameId = n.Id,
						PropertyNameTitle = n.Title,
						type = n.type,
					})
					.AsNoTracking()
					.ToList();
		}
		#endregion

		#region متد عملیاتی ثبت اطلاعات ویژه گی های کالاها یا محصولات

		public OperationResult CreateProductPropertyName(CreateProductPropertyNameViewModel propertyName)
		{
			bool Exist = ExistPropertyName(0, propertyName.PropertyGroupId, propertyName.PropertyNameTitle);

			if (Exist)
			{
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate
				};
			}

			TBL_ProductPropertyName propertyNewData = new TBL_ProductPropertyName()
			{
				CreationDate = DateTime.Now,
				Title = propertyName.PropertyNameTitle,
				GroupId = propertyName.PropertyGroupId,
				type = propertyName.type,
			};

			_context.TBL_ProductPropertyNames.Add(propertyNewData);
			_context.SaveChanges();

			AddPropertyNameForCategory(propertyName.Categories, propertyNewData.Id);

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}
		#endregion

		#region متد موجود بودن اطلاعات ویژه گی های کالاها یا محصولات
		public bool ExistPropertyName(int PropertyNameId, int PropertyGroupId, string PropertyNameTitle)
		{
			return _context.TBL_ProductPropertyNames
				.Any(x => x.Title == PropertyNameTitle && x.Id != PropertyNameId && x.GroupId == PropertyGroupId);
		}

		#endregion

		#region ID متد جستجوی موجود بودن اطلاعات ویژه گی های کالاها یا محصولات بر اساس 

		public TBL_ProductPropertyName FindPropertyNameById(int PropertyNameId)
		{
			return _context.TBL_ProductPropertyNames
				.Where(x => x.Id == PropertyNameId)
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی اضافه کردن نام خصوصیات و ویژه گی به دسته بندی
		public OperationResult AddPropertyNameForCategory(List<int> CategoryId, int PropertyNameId)
		{
			List<TBL_ProductPropertyNameCategory> propertyNameCategoriesNewData = new List<TBL_ProductPropertyNameCategory>();

			foreach (var item in CategoryId)
			{
				propertyNameCategoriesNewData.Add(new TBL_ProductPropertyNameCategory
				{
					CategoryId = item,
					CreationDate = DateTime.Now,
					PropertyNameId = PropertyNameId,
				});
			}

			_context.TBL_ProductPropertyNameCategories.AddRange(propertyNameCategoriesNewData);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region متد عملیاتی ویرایش نام ویژه گی های کالاها یا محصولات
		public OperationResult UpdateProductPropertyName(UpdateProductPropertyNamesViewModel UpdateNameTitle)
		{
			var FindPPN = FindPropertyNameById(UpdateNameTitle.PropertyNameTitleId);

			if (FindPPN == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool existPPN = ExistPPN(UpdateNameTitle.PropertyNameTitle, UpdateNameTitle.PropertyNameTitleId);
			if (existPPN)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			FindPPN.Title = UpdateNameTitle.PropertyNameTitle;
			FindPPN.LastModified = DateTime.Now;

			_context.TBL_ProductPropertyNames.Update(FindPPN);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}
		#endregion

		#region متد بروزرسانی اطلاعات ویژه گی های کالاها یا محصولات

		public UpdateProductPropertyNamesViewModel FindProductPropertyNamesByIdForUpdate(int NameTitleId)
		{
			return _context.TBL_ProductPropertyNames
				.Where(p => p.Id == NameTitleId)
				.Select(p => new UpdateProductPropertyNamesViewModel
				{
					PropertyNameTitleId = p.Id,
					PropertyNameTitle = p.Title,
				})
				.SingleOrDefault();
		}
		#endregion

		#region متد موجود بودن نام ویژه گی های کالاها یا محصولات و عملیات بر روی آن
		public bool ExistPPN(string titlePropertyName, int titlePropertyId)
		{
			return _context.TBL_ProductPropertyNames.Any(x => x.Title == titlePropertyName.Trim().ToLower() && x.Id != titlePropertyId
			);
		}
		#endregion

	}
}
