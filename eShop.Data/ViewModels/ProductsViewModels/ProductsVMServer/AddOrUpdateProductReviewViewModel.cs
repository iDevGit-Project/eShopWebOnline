using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer
{
    public class AddOrUpdateProductReviewViewModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string Review { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
    }
}
