using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.ExtentionMethods
{
	public static class PropertyType
	{
		///<summary>
		///انتخاب تکی
		///</summary>
		public const byte Single_Choice = 1;

		///<summary>
		/// چند انتخابی
		///</summary>
		public const byte Multiple_Choice = 2;

		///<summary>
		/// تک خطی
		///</summary>
		public const byte Linear = 3;

		///<summary>
		/// متن طولانی
		///</summary>
		public const byte Written = 4;
	}
}
