using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.ProductCategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController(IProductCategoryManager productCategoryManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(ProductCategoryDto productCategory) => await productCategoryManager.Upsert(productCategory);
    }
}
