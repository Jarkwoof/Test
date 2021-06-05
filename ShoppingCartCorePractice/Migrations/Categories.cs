using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartCorePractice.Migrations
{
    public class Categories
    {
        public Categories()
        {
            this.Products = new HashSet<Products>();
        }
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}