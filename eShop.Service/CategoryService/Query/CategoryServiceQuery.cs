using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using eShop.Data.ViewModels.CategoriesViewModels.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.CategoryService.Query
{
	public class CategoryServiceQuery : ICategoryServiceQuery
	{
		#region متد های پیکربندی اطلاعات دسته بندی در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public CategoryServiceQuery(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش تمام دسته بندی ها در سمت سرور یا مدیرسایت
		public List<GetCategoriesViewModel> GetCategories()
		{
			return _context.TBL_Categories
							.Select(x => new GetCategoriesViewModel
							{
								CategoryId = x.Id,
								EnTitle = x.EnTitle,
								FaTitle = x.FaTitle,
								ImgName = x.ImgName,
								IsActive = x.IsActive,
								IsMain = x.IsMain
							})
							.AsNoTracking()
							.ToList();
		}
		#endregion

		#region متد لیست نمایش دسته بندی ها جهت اضافه یا حذف رکدن زیردسته ها
		public List<GetParentCategoryForAddOrRemoveSubViewModel> GetParentCategoryForAddOrRemoveSub(int SubId)
		{
			var q = (from c in _context.TBL_Categories
					 join s in _context.TBL_SubCategories on c.Id equals s.ParentId

					 where s.SubId == SubId

					 select new GetParentCategoryForAddOrRemoveSubViewModel
					 {
						 CategoryId = c.Id,
						 FaTitle = c.FaTitle,
					 })
					.AsNoTracking()
					.ToList();
			return q;
		}
		#endregion

		#region متد نمایش دسته بندی های لیست پدر
		public List<GetCategoriesForParentListViewModel> GetCategoriesForParentList(int SubId)
		{
			return _context.TBL_Categories
				.Where(x => x.Id != SubId)
					.Select(x => new GetCategoriesForParentListViewModel
					{
						CategoryId = x.Id,
						EnTitle = x.EnTitle,
						FaTitle = x.FaTitle,
						ImgName = x.ImgName,
						IsActive = x.IsActive,
						IsMain = x.IsMain
					})
					.AsNoTracking()
					.ToList();
		}
		#endregion

		#region دسته بندی جهت حذف ID متد جستجوی دسته بندی بر اساس 
		public RemoveCategoryViewModel FindCategoryByIdForRemove(int CategoryId)
		{
			return _context.TBL_Categories
				.Where(x => x.Id == CategoryId)
				.Select(x => new RemoveCategoryViewModel
				{
					CategoryId = x.Id,
					Description = x.Description,
					EnTitle = x.EnTitle,
					FaTitle = x.FaTitle,
					Icon = x.Icon,
					IsActive = x.IsActive,
					IsMain = x.IsMain,
					OldImage = x.ImgName,

				})
				.FirstOrDefault();
		}
		#endregion

		#region آن جهت بروزرسانی ID متد جستجوی دسته بندی بر اساس 
		public UpdateCategoryViewModel FindCategoryByIdForUpdate(int CategoryId)
		{
			return _context.TBL_Categories
				.Where(x => x.Id == CategoryId)
				.Select(x => new UpdateCategoryViewModel
				{
					CategoryId = x.Id,
					Description = x.Description,
					EnTitle = x.EnTitle,
					FaTitle = x.FaTitle,
					Icon = x.Icon,
					IsActive = x.IsActive,
					IsMain = x.IsMain,
					OldImage = x.ImgName,

				})
				.FirstOrDefault();
		}
		#endregion

		#region ID متد جستجوی دسته بندی بر اساس 
		public TBL_Category FindCategoryById(int CategoryId)
		{
			return _context.TBL_Categories.Where(x => x.Id == CategoryId)
				.SingleOrDefault();
		}
		#endregion

		#region متد نمایش همه دسته بندی های پدر بر اساس زیردسته ها
		public List<TBL_SubCategory> GetAllParentBySubId(int SubId)
		{
			return _context.TBL_SubCategories
				.Where(x => x.SubId == SubId)
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد موجود بودن دسته بندی و عملیات آن
		public bool ExistCategory(int CategoryId, string FaTitle, string EnTitle)
		{
			return _context.TBL_Categories.Any(x => (x.FaTitle == FaTitle.ToLower().Trim() ||
			x.EnTitle == EnTitle.ToLower().Trim()) &&
			x.Id != CategoryId);
		}
		#endregion

		public List<GetCategoryForMenuViewModel> getCategoryForMenu()
		{
			var menu = (from c in _context.TBL_Categories
						join sub in _context.TBL_SubCategories on c.Id equals sub.SubId into ss
						from sub in ss.DefaultIfEmpty()
						where (c.IsActive == true && c.IsRemove == false)
						select new GetCategoryForMenuViewModel
						{
							CategoryId = c.Id,
							ParentId = sub.ParentId,
							FaTitle = c.FaTitle,
							IsMain = c.IsMain,
						})

						.ToList();
			return menu;
		}
	}
}
