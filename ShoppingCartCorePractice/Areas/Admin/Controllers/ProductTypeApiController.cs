using Microsoft.AspNetCore.Mvc;
using ShoppingCartCorePractice.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Controllers
{
    [Area("Admin")]
    public class ProductTypeApiController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypeApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var list = _db.Categories.ToList();
            return Ok(list);
        }
    }
}
