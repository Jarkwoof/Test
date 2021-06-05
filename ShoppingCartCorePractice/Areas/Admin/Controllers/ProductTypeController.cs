using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Controllers
{

    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _db.Categories.ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categories);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categories);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categories = _db.Categories.Find(id);
            if (Categories == null)
            {
                return NotFound();
            }
            return View(Categories);
        }

        public async Task<IActionResult> Update(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categories);
                await _db.SaveChangesAsync();          
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categories categories = _db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(categories);
                await _db.SaveChangesAsync();              
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }
    }
}
