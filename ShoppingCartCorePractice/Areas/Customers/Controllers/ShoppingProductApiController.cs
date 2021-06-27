using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class ShoppingProductApiController : Controller
    {
        private ApplicationDbContext _db;
        public ShoppingProductApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var query = (from x in _db.Products
                         join y in _db.Categories
                         on x.Category_Id equals y.Id
                         select x).ToList();

            return Ok(query);
        }
        public IActionResult test()
        {
            var query = "x";

            return Ok(query);
        }
        //public ActionResult AddToCart(int? id)
        //{
        //    List<Products> products = new List<Products>();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    products = HttpContext.Session.Get<List<Products>>("products");

        //}
    }
}
