using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteEFDemo.Models
{
    [Table("Vendor")]
    public class Vendor
    {
        [Key]
        [Required]
        public int VendorCode { get; set; }
        [MaxLength(64)]
        [Required]
        public String VendorName { get; set; }
        [Required]
        public String VendorContact { get; set; }
        [MaxLength(10)]
        public String VendorPhone { get; set; }
        [MaxLength(3)]
        public String VendorAreaCode { get; set; }
        [MaxLength(2)]
        public String VendorState { get; set; }

    }
}
