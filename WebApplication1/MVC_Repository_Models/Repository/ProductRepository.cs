//using System;
//using System.Collections.Generic;
//using System.Linq;
//using MVC_Repository_Models.Interface;
//using WebApplication1.Models.Repository;

//namespace MVC_Repository_Models.Repository
//{
//    public class ProductRepository : GenericRepository<Products>, IProductRepository, IDisposable
//    {
//        /// <summary>
//        /// Gets the by ID.
//        /// </summary>
//        /// <param name="productID">The product ID.</param>
//        /// <returns></returns>
//        /// <exception cref="System.NotImplementedException"></exception>
//        public Products GetByID(int productID)
//        {
//            return this.Get(x => x.ProductID == productID);
//        }

//        /// <summary>
//        /// Gets the by cateogy.
//        /// </summary>
//        /// <param name="categoryID">The category ID.</param>
//        /// <returns></returns>
//        /// <exception cref="System.NotImplementedException"></exception>
//        public IEnumerable<Products> GetByCategory(int categoryID)
//        {
//            return this.GetAll().Where(x => x.CategoryID == categoryID);
//        }

//        //        protected Service_repository_practiceEntities db
//        //        {
//        //            get;
//        //            private set;
//        //        }

//        //        public ProductRepository()
//        //        {
//        //            this.db = new Service_repository_practiceEntities();
//        //        }
//        //        public void Create(Products instance)
//        //        {
//        //            if(instance == null)
//        //            {
//        //                throw new ArgumentException("instance");
//        //            }
//        //            else
//        //            {
//        //                db.Products.Add(instance);
//        //                this.SaveChanges();
//        //            }
//        //        }

//        //        public void Delete(Products instance)
//        //        {
//        //            if(instance == null)
//        //            {
//        //                throw new ArgumentException("instance");
//        //            }
//        //            else
//        //            {
//        //                db.Entry(instance).State = EntityState.Deleted;
//        //                this.SaveChanges();
//        //            }
//        //        }

//        //        public Products Get(int productID)
//        //        {
//        //            return db.Products.FirstOrDefault(x => x.ProductID == productID);
//        //        }

//        //        public IQueryable<Products> GetAll()
//        //        {
//        //            return db.Products.Include(p => p.Categories).OrderByDescending(x => x.ProductID);
//        //        }

//        //        public void SaveChanges()
//        //        {
//        //            this.db.SaveChanges();
//        //        }

//        //        public void Update(Products instance)
//        //        {
//        //            if(instance == null)
//        //            {
//        //                throw new ArgumentException("instance");
//        //            }
//        //            else
//        //            {
//        //                db.Entry(instance).State = EntityState.Modified;
//        //                this.SaveChanges();
//        //            }
//        //        }

//        //        public void Dispose()
//        //        {
//        //            this.Dispose(true);
//        //            GC.SuppressFinalize(this);
//        //        }

//        //        protected virtual void Dispose(bool disposing)
//        //        {
//        //            if (disposing)
//        //            {
//        //                this.db.Dispose();
//        //                this.db = null;
//        //            }
//        //        }
//    }
//}