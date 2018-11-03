//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using WebApplication1.Models.Interface;

//namespace WebApplication1.Models.Repository
//{
//    public class CategoryReopsitory : ICategoryRepository, IDisposable
//    {
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
//    }
//}