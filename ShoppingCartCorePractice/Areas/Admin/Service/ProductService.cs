using Microsoft.EntityFrameworkCore;
using ShoppingCartCorePractice.Areas.Admin.Interface;
using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Service
{
    public class ProductService : IproductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Products _object)
        {
            if (_object == null)
            {
                return false;
            }
            var dbData = (_context.Products.Where(x => x.Id == _object.Id)).FirstOrDefault();
            if (dbData == null)
            {
                try
                {
                    _context.Products.Add(_object);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                  
                }
               
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(int? id)
        {
            var dbdata = (_context.Products.Where(x => x.Id == id).FirstOrDefault());
            if (dbdata != null)
            {
                _context.Remove(dbdata);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Products GetById(int? Id)
        {
            var data = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public bool Update(Products _object)
        {
            if (_object == null)
            {
                return false;
            }
            var dbData = (_context.Products.Where(x => x.Id == _object.Id)).FirstOrDefault();
            if (dbData != null)
            {
                dbData.Name = _object.Name;
                dbData.Description = _object.Description;
                dbData.Price = _object.Price;
                dbData.PhotoUrl = _object.PhotoUrl;
                dbData.Author = _object.Author;
                dbData.Publisher = _object.Publisher;
                dbData.PublishDT = _object.PublishDT;
                dbData.IsPublic = _object.IsPublic;
                dbData.Category_Id = _object.Category_Id;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProductDto> GetAll()
        {
            var query = (from x in _context.Products
                         join y in _context.Categories
                         on x.Category_Id equals y.Id
                         select new ProductDto 
                         { 
                            Name =x.Name,
                            Price =x.Price,
                            IsPublic =x.IsPublic,
                            CategoriesName =y.Name,
                            
                         }).ToList<ProductDto>();

            return query;
        }
    }
}
