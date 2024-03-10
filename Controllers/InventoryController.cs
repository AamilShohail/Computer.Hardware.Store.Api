using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.InventoryServices;
using Computer.Hardware.Store.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryManager inventoryManager) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(InventoryDto inventory) => await inventoryManager.Upsert(inventory);

        [HttpGet]
        public async Task<List<ProductInventory>> GetInventory() => await inventoryManager.GetInventoryDataAsync();
    }
}
