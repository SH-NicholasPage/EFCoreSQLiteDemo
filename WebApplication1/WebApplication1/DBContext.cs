using Microsoft.EntityFrameworkCore;
using SQLiteEFDemo.Models;

namespace SQLiteEFDemo
{
    public class DBContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Inventory.db");
        }

        public void FillTablesWithDemoInfo()
        {
            if (Inventory.Count() > 0 && Vendor.Count() > 0) return;

            Vendor.Add(new Vendor
            {
                VendorCode = 21225,
                VendorName = "Bryson Inc.",
                VendorContact = "Smithson",
                VendorAreaCode = "615",
                VendorPhone = "223-3234",
                VendorState = "TN"
            });
            Vendor.Add(new Vendor
            {
                VendorCode = 21226,
                VendorName = "SuperLoo, Inc",
                VendorContact = "Flushing",
                VendorAreaCode = "904",
                VendorPhone = "221-8995",
                VendorState = "FL"
            });
            Vendor.Add(new Vendor
            {
                VendorCode = 25595,
                VendorName = "Rubicon Systems",
                VendorContact = "Orton",
                VendorAreaCode = "904",
                VendorPhone = "456-0092",
                VendorState = "FL"
            });

            Inventory.Add(new Inventory
            {
                ProductCode = "11QER/31",
                ProductDescription = "Power painter, 15 psi. 3-nozzle",
                ProductInDate = DateOnly.Parse("03-Nov-17"),
                ProductQuantity = 8,
                ProductPrice = 109.99f,
                ProductVendor = Vendor.Find(25595)
            });
            Inventory.Add(new Inventory
            {
                ProductCode = "2238/QPD",
                ProductDescription = "B&D cordless drill, 1/2-in.",
                ProductInDate = DateOnly.Parse("20-Jan-18"),
                ProductQuantity = 12,
                ProductPrice = 38.95f,
                ProductVendor = Vendor.Find(25595)
            });
            Inventory.Add(new Inventory
            {
                ProductCode = "23109-HB",
                ProductDescription = "Claw hammer",
                ProductInDate = DateOnly.Parse("20-Jan-18"),
                ProductQuantity = 23,
                ProductPrice = 9.95f,
                ProductVendor = Vendor.Find(21125)
            });
            Inventory.Add(new Inventory
            {
                ProductCode = "23114-AA",
                ProductDescription = "Sledge hammer, 12 lb.",
                ProductInDate = DateOnly.Parse("20-Jan-18"),
                ProductQuantity = 23,
                ProductPrice = 9.95f
            });
            Inventory.Add(new Inventory
            {
                ProductCode = "WR3/TT3",
                ProductDescription = "Steel matting, 4'x8'x1/6\", .5\" mesh",
                ProductInDate = DateOnly.Parse("17-Jan-18"),
                ProductQuantity = 18,
                ProductPrice = 119.95f,
                ProductVendor = Vendor.Find(25595)
            });
            
            this.SaveChanges();
        }
    }
}
