using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.WarrantyServices;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyController(IWarrantyManager warrantyManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(WarrantyDto warranty) => await warrantyManager.Upsert(warranty);
    }
}
