using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Interface
{
    public interface IProductRepository : IRepository<Products>
    {
        //void Create(Products instance);

        //void Update(Products instance);

        //void Delete(Products instance);

        //Products Get(int productID);

        //IQueryable<Products> GetAll();

        //void SaveChanges();

        Products GetID(int productID);

        IEnumerable<Products> GetByCategory(int categoryID);
    }
}
