using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCartCorePractice.Areas.Admin.Interface;
using ShoppingCartCorePractice.Areas.Admin.Models;
using ShoppingCartCorePractice.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //private readonly IAdminService<Products> _ProductService;
        private readonly IAdminService<Categories> _CategoriesService;
        private readonly IproductService _Productsvc;
        //private ApplicationDbContext _db;
        private IWebHostEnvironment _he;
       

        public ProductController(
            IAdminService<Categories> CategoriesService,
            IproductService Productsvc,
            IWebHostEnvironment he)
        {
          
            _CategoriesService = CategoriesService;
            _Productsvc = Productsvc;
            _he = he;
        }
        public IActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductList = _Productsvc.GetAll();       
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(_CategoriesService.GetAll().ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products Products, IFormFile PhotoUrl)
        {
            if (PhotoUrl != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(PhotoUrl.FileName));
                PhotoUrl.CopyToAsync(new FileStream(name, FileMode.Create));
                Products.PhotoUrl = "Images/" + PhotoUrl.FileName;
            }
            else
            {
                Products.PhotoUrl = "Images/noimage.PNG";
            }
            var CreateData = _Productsvc.Create(Products);
            if (CreateData == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category_Id = new SelectList(_CategoriesService.GetAll().ToList(), "Id", "Name");
                return View("Create", Products);
            }
        }

        public ActionResult Edit(int? id)
        {
            var EditData = _Productsvc.GetById(id);
            ViewBag.Category_Id = new SelectList(_CategoriesService.GetAll().ToList(), "Id", "Name");
            if (EditData == null)
            {
                return NotFound();
            }
            return View(EditData);
        }

        public ActionResult Update(Products product)
        {
            var result = _Productsvc.Update(product);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category_Id = new SelectList(_CategoriesService.GetAll().ToList(), "Id", "Name");
                return View("Edit", product);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DeleteData = _Productsvc.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
