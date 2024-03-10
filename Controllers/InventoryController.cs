using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.InventoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryManager inventoryManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(InventoryDto inventory) => await inventoryManager.Upsert(inventory);
    }
}
