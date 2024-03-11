using Computer.Hardware.Store.Service.CSVServices;
using Computer.Hardware.Store.Service.Dto;
using Computer.Hardware.Store.Service.Enums;
using Computer.Hardware.Store.Service.InventoryServices;
using Computer.Hardware.Store.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Hardware.Store.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryController(IInventoryManager inventoryManager, ICSVService csvService) : ControllerBase
    {
        [HttpPost]
        public async Task<int?> Upsert(InventoryDto inventory) => await inventoryManager.Upsert(inventory);

        [HttpGet]
        public async Task<List<ProductInventory>> GetInventory() => await inventoryManager.GetInventoryDataAsync();

        [HttpPost]
        public async Task<List<ProductInventory>> Upload(IFormFileCollection file)
        {
            var productInventories = csvService.ReadCSV<ProductInventory>(file: file[0].OpenReadStream()).ToList();
            foreach (var product in productInventories)
            {
                await inventoryManager.Upsert(new()
                {
                    BufferStock = product.BufferStock,
                    Discount = product.Discount,
                    Quantity = product.Quantity,
                    Stock = product.Stock,
                    UnitCost = product.ListPrice,
                    WarrantyID = (int?)WarrantyEnum.Christmas,
                    Product = new()
                    {
                        SerialNumber = product.SerialNumber,
                        VendorID = (int)VendorEnum.PChouse,
                        ListPrice = product.ListPrice,
                        ProductCategoryID = (int)ProductCategoryEnum.MemoryDevices

                    },
                });
            }
            return productInventories;
        }
    }
}
