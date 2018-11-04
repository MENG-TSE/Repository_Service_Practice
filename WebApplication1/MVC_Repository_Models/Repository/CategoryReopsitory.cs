using MVC_Repository_Models.Interface;
using System;
using WebApplication1.Models.Repository;

namespace MVC_Repository_Models.Repository
{
    //public class CategoryReopsitory : ICategoryRepository, IDisposable
    //{
    public class CategoryReopsitory : GenericRepository<Categories>, ICategoryRepository, IDisposable
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public Categories GetByID(int categoryID)
        {
            return this.Get(X => X.CategoryID == categoryID);
        }

        //        protected Service_repository_practiceEntities db
        //        {
        //            get;
        //            private set;
        //        }

        //        public CategoryReopsitory()
        //        {
        //            this.db = new Service_repository_practiceEntities();
        //        }
        //        public void Create(Categories instance)
        //        {
        //            if(instance == null)
        //            {
        //                throw new ArgumentException("instance");
        //            }
        //            else
        //            {
        //                db.Categories.Add(instance);
        //                this.SaveChanges();
        //            }
        //        }

        //        public void Delete(Categories instance)
        //        {
        //            if(instance == null)
        //            {
        //                throw new ArgumentException("intance");
        //            }
        //            else
        //            {
        //                db.Entry(instance).State = EntityState.Deleted;
        //                this.SaveChanges();
        //            }
        //        }

        //        public Categories Get(int categoryID)
        //        {
        //            return db.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
        //        }

        //        public IQueryable<Categories> GetAll()
        //        {
        //            return db.Categories.OrderBy(x => x.CategoryID);
        //        }

        //        public void SaveChanges()
        //        {
        //            this.db.SaveChanges();
        //        }

        //        public void Dispose()
        //        {
        //            this.Dispose(true);
        //            GC.SuppressFinalize(this);
        //        }

        //        protected virtual void Dispose(bool disposing)
        //        {
        //            if(disposing)
        //            {
        //                this.db.Dispose();
        //                this.db = null;
        //            }
        //        }

        //        public void Update(Categories instance)
        //        {
        //            if(instance == null)
        //            {
        //                db.Entry(instance).State = EntityState.Modified;
        //                this.SaveChanges();
        //            }
        //        }
    }
}