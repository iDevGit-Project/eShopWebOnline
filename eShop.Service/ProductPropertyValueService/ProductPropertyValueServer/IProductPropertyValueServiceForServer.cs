﻿using eShop.Common.Operations;
using eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer;
using eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyValueService.ProductPropertyValueServer
{
	public interface IProductPropertyValueServiceForServer
	{
		List<GetProductPropertyValuesViewModel> GetProductPropertyValues();
		OperationResult<int> CreateProductPropertyValue(CreateProductPropertyValueViewModel propertyValue);
		
		//  مقادیر در جدول Title متد های بروزرسانی عنوان یا 
		UpdateProductPropertyValueTitleViewModel FindProductPropertyValuesByIdForUpdate(int ValueTitleId);
		OperationResult UpdateProductPropertyValueTitle(UpdateProductPropertyValueTitleViewModel UpdateValueTitle);

		#region متد های مربوط به جدول ویژه گی های محصولات یا کالاها
		List<AddProductPropertyNameForProductViewModel> GetProductPropertyNameForProductByCategoryId(int CategoryId);
		List<ProductPropertyOldValueForProductViewModel> oldProductPropertyValueForProduct(int ProductId);
		OperationResult AddOrRemoveProductPropertyForProduct(AddOrUpdateProductPropertyValueForProductViewModel addOrUpdateProperty);
		#endregion
	}
}
