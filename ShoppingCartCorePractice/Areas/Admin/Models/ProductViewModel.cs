using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public List<ProductDto> ProductList { get; set; }

        public ProductViewModel()
        {
            ProductList = new List<ProductDto>();
        }
    }


}
