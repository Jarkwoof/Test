using ShoppingCartCorePractice.Areas.Admin.Interface;
using ShoppingCartCorePractice.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Service
{
    public class CategoriesService : IAdminService<Categories>
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categories> GetAll()
        {
            var query = (from x in _context.Categories select x).ToList();
            return query;
        }
        public bool Create(Categories _object)
        {
            if (_object == null)
            {
                return false;
            }
            var dbData = (_context.Categories.Where(x => x.Id == _object.Id)).FirstOrDefault();
            if (dbData == null)
            {
                _context.Categories.Add(_object);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Update(Categories _object)
        {
            if (_object == null)
            {
                return false;
            }
            var dbData = (_context.Categories.Where(x => x.Id == _object.Id)).FirstOrDefault();
            if(dbData != null)
            {
                dbData.Name = _object.Name;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            var dbdata = (_context.Categories.Where(x => x.Id == id).FirstOrDefault());
            if(dbdata != null)
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
        public Categories GetById(int? Id)
        {
            var data = _context.Categories.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            return data;

        }
    }
}
