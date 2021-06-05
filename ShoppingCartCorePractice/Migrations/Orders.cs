using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartCorePractice.Migrations
{
    public class Orders
    {
        public Orders()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ContactName { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ContactPhone { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ContactAddress { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public System.DateTime BuyDT { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Memo { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}