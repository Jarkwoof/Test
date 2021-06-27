using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Customers.Models
{
    //public class Cart : IEnumerable<CartItem>
    //{
    //    private List<CartItem> cartItems;
    //    public Cart()
    //    {
    //        this.cartItems = new List<CartItem>();
    //    }
    //    public IEnumerator<CartItem> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    //購物車內商品總數量
    //    public int Count
    //    {
    //        get
    //        {
    //            return this.cartItems.Count();
    //        }
    //    }
    //    //購物車內商品總價
    //    public decimal TotalAmount
    //    {
    //        get
    //        {
    //            decimal totalAmount = 0.0m;
    //            foreach (var cartItem in this.cartItems)
    //            {
    //                totalAmount = totalAmount + cartItem.Amount;
    //            }
    //            return totalAmount;
    //        }
    //    }
    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return this.cartItems.GetEnumerator();
    //    }
    //}

    public class Cart
    {

        public List<CartItem> CartItemList { get; set; }

        public double TotalPrice { get; set; }
    }

}
