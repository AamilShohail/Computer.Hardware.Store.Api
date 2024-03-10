using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.VendorServices;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController(IVendorManager vendorManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(VendorDto vendor) => await vendorManager.Upsert(vendor);
    }
}
