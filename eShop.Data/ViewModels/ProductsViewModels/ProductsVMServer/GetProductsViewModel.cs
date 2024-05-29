using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer
{
    public class GetProductsViewModel
    {
        public int ProductId { get; set; }
        public string ImgName { get; set; }
        public string FaTitle { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
