using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartCorePractice.Areas.Admin.Interface;
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
      
        private readonly IAdminService<Categories> _AdminService;
        public ProductTypeController(IAdminService<Categories> AdminService)
        {
            _AdminService = AdminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var list = _AdminService.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            var CreateData = _AdminService.Create(categories);

            if (CreateData == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create",CreateData);
            }
        }


        public ActionResult Edit(int? id)
        {
            var EditData = _AdminService.GetById(id);
            if(EditData == null)
            {
               return NotFound();
            }
            return View(EditData);
        }

        public ActionResult Update(Categories categories)
        {
            var result = _AdminService.Update(categories);
            if(result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Update", categories);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var DeleteData = _AdminService.Delete(id);              
            return RedirectToAction("Index");
                      
        }
    }
}
