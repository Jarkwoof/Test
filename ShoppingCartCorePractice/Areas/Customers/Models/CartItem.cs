using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Customers.Models
{
    [Serializable]
    public class CartItem
    {
        //商品編號
        public int Id { get; set; }
        //名稱
        public string Name { get; set; }
        //定價
        public decimal Price { get; set; }
        //數量
        public int Quantity { get; set; }
        //小計
        public decimal Amount
        {
            get
            {
                return (this.Price * this.Quantity);
            }
        }
        //封面
        public string PhotoUrl { get; set; }
    }
}
