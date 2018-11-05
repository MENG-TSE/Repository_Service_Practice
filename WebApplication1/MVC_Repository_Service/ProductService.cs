using MVC_Repository_Models;
using MVC_Repository_Service.Interface;
using MVC_Repository_Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repository;

namespace MVC_Repository_Service
{
    public class ProductService : IProductService
    {
        //private IRepository<Products> repository = new GenericRepository<Products>();
        private IRepository<Products> _repository;

        public ProductService(IRepository<Products> repository)
        {
            this._repository = repository;
        }

        public IResult Create(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException();
            }
            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Products instance)
        {
            if(instance == null)
            {
                throw new ArgumentNullException();
            }
            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }
        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if(!this.IsExists(productID))
            {
                result.Message = "找不到資料";
            }
            try
            {
                var instance = this.GetByID(productID);
                this._repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Products> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetByCategory(int categoryID)
        {
            return this._repository.GetAll().Where(x => x.CategoryID == categoryID);
        }

        public Products GetByID(int productID)
        {
            return this._repository.Get(x => x.ProductID == productID);
        }

        public bool IsExists(int productID)
        {
            return this._repository.GetAll().Any(x => x.ProductID == productID);
        }

    }
}
