using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC_Repository_Models;
//using MVC_Repository_Models.Repository;
using MVC_Repository_Service;
using MVC_Repository_Service.Interface;
using WebApplication1.Models.Repository;

namespace MVC_Repository_Web.Controllers
{
    public class ProductController : Controller
    {
        //private IProductRepository productRepository;
        //private ICategoryReopsitory categoryRepository;

        private IProductService _productService;
        private ICategoryService _categoryService;


        public IEnumerable<Categories> Categories
        {
            get
            {
                return _categoryService.GetAll();
            }
        }

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index(string category = "all")
        {
            var products = _productService.GetAll()
                .OrderByDescending(x => x.ProductID)
                .ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id,string category)
        {
            //Products product = productRepository.Get(x => x.ProductID == id);
            Products product = _productService.GetByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create(string category)
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName");
            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products products, string category)
        {
            if(ModelState.IsValid)
            {
                this._productService.Create(products);
                return RedirectToAction("Index", new { Category = category });
            }
            ViewBag.CategoryID = new SelectList(this.Categories,"CategoryID","CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id, string category)
        {
            //Products product = this.productRepository.Get(x => x.ProductID == id);
            Products product = this._productService.GetByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.Category = string.IsNullOrWhiteSpace(category) ? "all" : category;
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products products, string category)
        {
            if(ModelState.IsValid)
            {
                this._productService.Update(products);
                return RedirectToAction("Index", new { Category = category });
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id,string category)
        {
            if (!id.HasValue) return RedirectToAction("index");

            //Products product = this.productRepository.Get(x => x.ProductID == id);
            Products product = this._productService.GetByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, string category)
        {
            //Products product = this.productRepository.Get(x => x.ProductID == id);
            Products product = this._productService.GetByID(id);

            this._productService.Delete(id);
            return RedirectToAction("Index", new { Category = category });
        }
    }
}
