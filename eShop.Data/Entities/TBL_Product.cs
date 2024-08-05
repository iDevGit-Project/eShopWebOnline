using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Product : TBLMASTER_BaseEntity
	{
		public string ImgName { get; set; }

		[Display(Name = "نام کالا (فارسی)")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string FaTitle { get; set; }

		[Display(Name = "نام کالا (انگلیسی)")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string EnTitle { get; set; }
		public int CategoryId { get; set; }
		public int BrandId { get; set; }
		public bool IsActive { get; set; }
		public int Score { get; set; }

		#region ارتباط جداول
		[ForeignKey(nameof(CategoryId))]
		public TBL_Category TBLCategory { get; set; }

		[ForeignKey(nameof(BrandId))]
		public TBL_Brand TBLBrand { get; set; }

		//=========================================================
		public List<TBL_ProductGallery> TBLProductGalleries { get; set; }
		public List<TBL_ProductReview> TBLProductReviews { get; set; }
		public List<TBL_ProductProperty> TBLProductsProperties { get; set; }
		public List<TBL_ProductPrice> TBLProductPrices { get; set; }
		public List<TBL_ProductQuestion> TBLProductQuestions { get; set; }
		#endregion
	}
}
