using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Interface
{
    public interface ICategoryRepository : IRepository<Categories>
    {
        //void Create(Categories instance);

        //void Update(Categories instance);

        //void Delete(Categories instance);

        //Categories Get(int categoryID);

        //IQueryable<Categories> GetAll();

        //void SaveChanges();

        Categories GetByID(int categoryID);
    }
}
