using MVC_Repository_Models;
using System.Collections;
using System.Collections.Generic;
using MVC_Repository_Service.Misc;

namespace MVC_Repository_Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(Categories instance);

        IResult Update(Categories instance);

        IResult Delete(int categoryID);

        Categories GetByID(int categoryID);

        IEnumerable<Categories> GetAll();
    }
}