using System.ComponentModel.DataAnnotations; // Key attribute
using System.ComponentModel.DataAnnotations.Schema; // Table attribute

namespace SimpleDatabase.Entities
{
    [Table("Products")]
    public class ProductItem
    {
        [Key]
        public int ProductID { get; set; }      // ProductID        int
        [Column("ProductName")]
        public string Name { get; set; }        // ProductName      nvarchar(40)
        public int SupplierID { get; set; }     // SupplierID       int
        public int CategoryID { get; set; }     // CategoryID       int
        [NotMapped]
        public string Supplier { get; set; }     // does not appear on the Products table
        [NotMapped]
        public string Category { get; set; }    // does not appear on the Products table
        [Column("UnitPrice")]
        public decimal SuggestedUnitPrice { get; set; }
        public string QuantityPerUnit { get; set; } // QuantityPerUnit  nvarchar(20)
    }
}