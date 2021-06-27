using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartCorePractice.Migrations
{
    public class Products
    {
        public Products()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        public int Category_Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string PhotoUrl { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Author { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Publisher { get; set; }
        public System.DateTime PublishDT { get; set; }
        public bool IsPublic { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}