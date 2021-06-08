using ShoppingCartCorePractice.Migrations;
using ShoppingCartCorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Interface
{
    public interface IproductService
    {
        public bool Create(Products _object);

        public bool Update(Products _object);

        public List<ProductDto> GetAll();

        public Products GetById(int? Id);

        public bool Delete(int? id);
    }
}
