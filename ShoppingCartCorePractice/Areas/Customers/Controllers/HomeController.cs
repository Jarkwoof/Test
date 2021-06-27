using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartCorePractice.Areas.Customers.Models;
using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Customers
{
    [Area("Customers")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var query = (from x in _db.Products
                         join y in _db.Categories
                         on x.Category_Id equals y.Id
                         select x ).ToList();                                                                     
            return View(query);
        }

        public ActionResult AddToCart(int? Id)
        {
            List<Products> products = new List<Products>();
            if (Id == null)
            {
                return NotFound();
            }
            //var shopCart = HttpContext.Session.Get<List<Products>>("products");
           var shopCart= SessionHelper.Get<Cart>(HttpContext.Session, "cart");
            Console.WriteLine(shopCart);
            return Ok();
        }
    }
}
