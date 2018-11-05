using System.Collections;
using System.Collections.Generic;
using MVC_Repository_Models;
using MVC_Repository_Service.Misc;

namespace MVC_Repository_Service.Interface
{
    public interface IProductService
    {
        IResult Create(Products instance);

        IResult Update(Products instance);

        IResult Delete(int productID);

        bool IsExists(int productID);

        Products GetByID(int productID);

        IEnumerable<Products> GetAll();

        IEnumerable<Products> GetByCategory(int categoryID);
    }
}