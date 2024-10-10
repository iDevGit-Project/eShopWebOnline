using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using eShop.Service.CategoryService.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.CategoryService.Command
{
	public class CategoryServiceCommand : ICategoryServiceCommand
	{

		#region متد های پیکربندی اطلاعات دسته بندی در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		private readonly ICategoryServiceQuery _categoryServiceQuery;

		public CategoryServiceCommand(ApplicationDbContext context, ICategoryServiceQuery categoryServiceQuery)
		{
			_context = context;
			_categoryServiceQuery = categoryServiceQuery;
		}
		#endregion

		#region متد عملیات اضافه یا بروزرسانی دسته بندی پدر بر اساس اطلاعات زیردسته ها
		public OperationResult AddOrUpdateParentCategory(AddOrUpdateParentCategoryViewModel addOrUpdate)
		{
			List<TBL_SubCategory> AddParent = new List<TBL_SubCategory>();
			List<TBL_SubCategory> RemoveParent = new List<TBL_SubCategory>();
			List<TBL_SubCategory> OldParent = _categoryServiceQuery.GetAllParentBySubId(addOrUpdate.SubId);

			if (OldParent.Count() > 0)
			{
				foreach (var item in OldParent)
				{
					if (addOrUpdate.ParentId != null)
					{
						if (addOrUpdate.ParentId.Contains(item.ParentId))
						{
							addOrUpdate.ParentId.Remove(item.ParentId);
						}
						else
						{
							RemoveParent.Add(new TBL_SubCategory
							{
								Id = item.Id,
							});
						}
					}
					else
					{
						RemoveParent.Add(new TBL_SubCategory
						{
							Id = item.Id,
						});
					}


				}
				_context.TBL_SubCategories.RemoveRange(RemoveParent);
			}

			if (addOrUpdate.ParentId != null)
			{
				foreach (var item in addOrUpdate.ParentId)
				{
					if (OldParent.Any(x => x.SubId == addOrUpdate.SubId
					&& x.ParentId == item) == false)
					{
						AddParent.Add(new TBL_SubCategory
						{
							SubId = addOrUpdate.SubId,
							ParentId = item,
							CreationDate = DateTime.Now,

						});
					}
				}
			}

			_context.TBL_SubCategories.AddRange(AddParent);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update

			};
		}
		#endregion

		#region متد عملیات ثبت دسته بندی جدید
		public OperationResult<int> CreateCategory(CreateCategoryViewModel createCategory)
		{
			bool existCategory = _categoryServiceQuery.ExistCategory(0, createCategory.FaTitle, createCategory.EnTitle);
			if (existCategory)
			{
				return new OperationResult<int>
				{
					Code = OperationCode.duplicate,
					Data = 0,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate
				};
			}

			string imageName = createCategory.ImgName.UplodeImage(ImagePathExtention.PathCategoryImageServer);
			TBL_Category newDataCategory = new TBL_Category()
			{
				CreationDate = DateTime.Now,
				Description = createCategory.Description,
				EnTitle = createCategory.EnTitle.ToLower().Trim(),
				FaTitle = createCategory.FaTitle.ToLower().Trim(),
				ImgName = imageName,
				IsActive = createCategory.IsActive,
				IsMain = createCategory.IsMain
			};

			_context.TBL_Categories.Add(newDataCategory);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = newDataCategory.Id,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region متد عملیات حذف دسته بندی
		public OperationResult RemoveCategory(RemoveCategoryViewModel RemoveCategory)
		{
			var FindCategory = _categoryServiceQuery.FindCategoryById(RemoveCategory.CategoryId);

			if (FindCategory == null)
			{
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound
				};
			}

			FindCategory.RemoveDate = DateTime.Now;
			FindCategory.IsRemove = true;

			_context.TBL_Categories.Update(FindCategory);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Remove,
			};
		}
		#endregion

		#region متد عملیات بروزرسانی دسته بندی
		public OperationResult<int> UpdateCategory(UpdateCategoryViewModel updateCategory)
		{
			var FindCategory = _categoryServiceQuery.FindCategoryById(updateCategory.CategoryId);

			if (FindCategory == null)
			{
				return new OperationResult<int>
				{
					Code = OperationCode.Failed,
					Data = 0,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound
				};
			}

			bool existCategory = _categoryServiceQuery.ExistCategory(updateCategory.CategoryId, updateCategory.FaTitle, updateCategory.EnTitle);
			if (existCategory)
			{
				return new OperationResult<int>
				{
					Code = OperationCode.duplicate,
					Data = 0,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate
				};
			}

			if (updateCategory.ImgName != null)
			{
				ImageExtention.RemoveImage(FindCategory.ImgName, ImagePathExtention.PathCategoryImageServer);
				FindCategory.ImgName = updateCategory.ImgName.UplodeImage(ImagePathExtention.PathCategoryImageServer);
			}

			FindCategory.LastModified = DateTime.Now;
			FindCategory.Description = updateCategory.Description;
			FindCategory.EnTitle = updateCategory.EnTitle.ToLower().Trim();
			FindCategory.FaTitle = updateCategory.FaTitle.ToLower().Trim();
			FindCategory.IsActive = updateCategory.IsActive;
			FindCategory.IsMain = updateCategory.IsMain;


			_context.TBL_Categories.Update(FindCategory);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = updateCategory.CategoryId,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion
	}
}
