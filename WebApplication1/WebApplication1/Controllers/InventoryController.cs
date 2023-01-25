using Microsoft.AspNetCore.Mvc;
using SQLiteEFDemo.Models;

namespace SQLiteEFDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpPut(Name = "PutInventory")]
        public Object Put(Inventory? item = null)
        {
            if (item == null) return BadRequest();

            using (DBContext client = new DBContext())
            {
                Inventory? inventoryItem = client.Inventory.FirstOrDefault(x => x.ProductCode == item.ProductCode);
                if (inventoryItem == null)
                {
                    return NotFound();
                }
                
                inventoryItem.ProductDescription = item.ProductDescription;
                inventoryItem.ProductInDate = item.ProductInDate;
                inventoryItem.ProductQuantity = item.ProductQuantity;
                inventoryItem.ProductPrice = item.ProductPrice;
                inventoryItem.ProductVendor = item.ProductVendor;
                client.SaveChanges();
                return Ok(item);
            }
        }
    }
}
