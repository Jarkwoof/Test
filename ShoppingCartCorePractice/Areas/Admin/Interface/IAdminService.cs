using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartCorePractice.Areas.Admin.Interface
{
    public interface IAdminService<T>
    {
        public bool Create(T _object);

        public bool Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int? Id);

        public bool Delete(int? id);
    }
}
