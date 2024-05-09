using eShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		#region DbSets All Tables
		public DbSet<TBL_Brand> TBL_Brands { get; set; }
		public DbSet<TBL_Warranty> TBL_Warranties { get; set; }
		public DbSet<TBL_Slider> TBL_Sliders { get; set; }
		public DbSet<TBL_Category> TBL_Categories { get; set; }
		public DbSet<TBL_SubCategory> TBL_SubCategories { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// عملیات حذف برای جدول برند
			modelBuilder.Entity<TBL_Brand>().HasQueryFilter(b => b.IsRemove == false);
			// عملیات حذف برای جدول برند
			modelBuilder.Entity<TBL_Warranty>().HasQueryFilter(w => w.IsRemove == false);
			// عملیات حذف برای جدول اسلایدر
			modelBuilder.Entity<TBL_Slider>().HasQueryFilter(s => s.IsRemove == false);
			// عملیات حذف برای جدول دسته بندی ها
			modelBuilder.Entity<TBL_Category>().HasQueryFilter(c => c.IsRemove == false);

			//================================================================================

			// رفع خطای مشکل زمانی که مثلاً اگر منوی اصلی حذف شد، زیرمنوهای آن نیز حذف می شوند
			var cacade = modelBuilder.Model.GetEntityTypes()
			.SelectMany(x => x.GetForeignKeys())
			.Where(x => !x.IsOwnership && x.DeleteBehavior == DeleteBehavior.Cascade);

			foreach (var type in cacade)
				type.DeleteBehavior = DeleteBehavior.Restrict;
			base.OnModelCreating(modelBuilder);
		}
	}
}
