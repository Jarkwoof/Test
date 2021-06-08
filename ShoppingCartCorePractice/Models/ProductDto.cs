using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Models
{
    public class ProductDto
    {
        public int Id { get; set; }    
        public string Name { get; set; }  
        public string Description { get; set; }
        public int Category_Id { get; set; } 
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }   
        public string Author { get; set; }
        public string Publisher { get; set; }
        public System.DateTime PublishDT { get; set; }
        public bool IsPublic { get; set; }
        public string CategoriesName { get; set; }
    }
}
