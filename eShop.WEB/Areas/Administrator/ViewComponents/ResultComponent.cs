using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShop.WEB.Areas.Administrator.ViewComponents
{
    public class ResultComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            OperationResult result = new OperationResult();

            if (TempData[TempDataName.ResultTempdata] != null)
            {
                result = JsonConvert.DeserializeObject<OperationResult>(TempData[TempDataName.ResultTempdata].ToString());
            }

            if (TempData[TempDataName.ResultParentTempdata] != null)
            {
                result = JsonConvert.DeserializeObject<OperationResult>(TempData[TempDataName.ResultParentTempdata].ToString());
            }

            return await Task.FromResult(View("ResultMessages", result));
        }
    }
}
