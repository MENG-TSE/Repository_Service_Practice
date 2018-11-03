//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using WebApplication1.Models.Interface;

//namespace WebApplication1.Models.Repository
//{
//    public class ProductRepository : IProductRepository,IDisposable
//    {
//        protected Service_repository_practiceEntities db
//        {
//            get;
//            private set;
//        }

//        public ProductRepository()
//        {
//            this.db = new Service_repository_practiceEntities();
//        }
//        public void Create(Products instance)
//        {
//            if(instance == null)
//            {
//                throw new ArgumentException("instance");
//            }
//            else
//            {
//                db.Products.Add(instance);
//                this.SaveChanges();
//            }
//        }

//        public void Delete(Products instance)
//        {
//            if(instance == null)
//            {
//                throw new ArgumentException("instance");
//            }
//            else
//            {
//                db.Entry(instance).State = EntityState.Deleted;
//                this.SaveChanges();
//            }
//        }

//        public Products Get(int productID)
//        {
//            return db.Products.FirstOrDefault(x => x.ProductID == productID);
//        }

//        public IQueryable<Products> GetAll()
//        {
//            return db.Products.Include(p => p.Categories).OrderByDescending(x => x.ProductID);
//        }

//        public void SaveChanges()
//        {
//            this.db.SaveChanges();
//        }

//        public void Update(Products instance)
//        {
//            if(instance == null)
//            {
//                throw new ArgumentException("instance");
//            }
//            else
//            {
//                db.Entry(instance).State = EntityState.Modified;
//                this.SaveChanges();
//            }
//        }

//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                this.db.Dispose();
//                this.db = null;
//            }
//        }
//    }
//}