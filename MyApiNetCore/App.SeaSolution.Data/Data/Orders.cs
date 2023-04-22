using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.SeaSolution.Data.Data
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers? Customers { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products? Products { get; set; }

        public string Address { get; set; }
        public int Quantity { get; set; }
    }
}
