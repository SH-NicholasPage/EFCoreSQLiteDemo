using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteEFDemo.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        [Required]
        public String ProductCode { get; set; }
        [Required]
        [MaxLength(64)]
        public String ProductDescription { get; set; }
        public DateOnly ProductInDate { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public Vendor? ProductVendor { get; set; }
    }
}
