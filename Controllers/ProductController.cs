using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductManager productManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(ProductDto product) => await productManager.Upsert(product);

    }
}
