using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Common.Operations
{
	public static class OperationResultMessage
	{
		public static string Create = "ثبت اطلاعات با موفقیت انجام شد.";
		public static string Update = "اطلاعات با موفقیت بروزرسانی شد.";
		public static string Remove = "اطلاعات با موفقیت حذف شد.";
		public static string Failed = "خطا در انجام عملیات. لطفاً دقایقی دیگر تلاش کنید.";
		public static string Duplicate = "کاربرگرامی: داده های وارد شده تکراریست.";
		public static string NotFound = "کاربرگرامی: چنین مقداری در برنامه یافت نشد...";
		public static string NoInputData = "هیچ داده ای وارد نشده است.";
		public static string DuplicateEmail = "ایمیل وارد شده تکراری است.";
		public static string Register = "حساب کاربری با موفقیت ایجاد شد/ ایمیل فعال سازی برای شما ارسال شد";
		public static string NotFoundUser = "کاربری با این مشخصات یافت نشد.";
		public static string BanUser = "حساب کاربری شما مسدود شده است.";
		public static string ActiveAccount = "حساب کاربری شما با موفقیت فعال شد.";
		public static string LogIn = "با موفقیت وارد شدید.";
		public static string LogOut = "با موفقیت خارج شدید.";
		public static string ForgotPassword = "ایمیل بازیابی با موفقیت ارسال شد.";
		public static string SuccessForgotPassword = "کلمه عبور با موفقیت ویرایش شد.";
		public static string AddProductForCart = "محصول با موفقیت به سبد خرید شما اضافه شد.";
		public static string RedirectToZarinPal = "...درحال انتقال به درگاه زرین پال";
		public static string VerificationZarinPal = "سفارش شما با موفقیت ثبت شد.";
		public static string NotVerificationZarinPal = "خطا در ثبت سفارش...";
		public static string AccessDenied = "مجاز به دیدن این صفحه نیستید.";
		public static string Access = "مجاز به دیدن این صفحه هستید.";
	}
}
