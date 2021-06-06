using Admin.DATA.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCartCorePractice
namespace Admin.DATA.Service
{
  
    public class AdminService: IRepository<>
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<product> GetAll()
        {

        }
    }
}
