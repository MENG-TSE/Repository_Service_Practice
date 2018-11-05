using System.Data;
using System.Linq;
using System.Web.Mvc;
using MVC_Repository_Models;
using MVC_Repository_Models.Interface;
using MVC_Repository_Models.Repository;
using MVC_Repository_Service;
using MVC_Repository_Service.Interface;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repository;

namespace MVC_Repository_Web.Controllers
{
    

    public class CategoryController : Controller
    {
        //private ICategoryRepository categoryRepository;
        private ICategoryService categoryService;

        public CategoryController()
        {
            this.categoryService = new CategoryService();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll()
                    .OrderByDescending(x => x.CategoryID)
                    .ToList();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                //var category = this.categoryRepository.Get(x =>x.CategoryID == id.Value);
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Categories category)
        {
            if(category != null && ModelState.IsValid)
            {
                this.categoryService.Create(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                //var category = this.categoryRepository.Get(x => x.CategoryID == id.Value);
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Categories category)
        {
            if(category != null && ModelState.IsValid)
            {
                this.categoryService.Update(category);
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                //var category = this.categoryRepository.Get(id.Value);
                //var category = this.categoryRepository.Get(x => x.CategoryID == id.Value);
                var category = this.categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Category/Delete/5
        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //var category = this.categoryRepository.Get(x => x.CategoryID == id);
                var category = this.categoryService.GetByID(id);
                this.categoryService.Delete(id);
            }
            catch(DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }
    }
}
