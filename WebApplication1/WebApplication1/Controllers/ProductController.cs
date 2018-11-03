﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Products> productRepository;
        private IRepository<Categories> categoryRepository;

        public IEnumerable<Categories> Categories
        {
            get
            {
                return categoryRepository.GetAll();
            }
        }

        public ProductController()
        {
            this.productRepository = new GenericRepository<Products>();
            this.categoryRepository = new GenericRepository<Categories>();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = productRepository.GetAll()
                .OrderByDescending(x => x.ProductID)
                .ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id = 0)
        {
            Products product = productRepository.Get(x => x.ProductID == id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products products)
        {
            if(ModelState.IsValid)
            {
                this.productRepository.Create(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.Categories,"CategoryID","CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Products product = this.productRepository.Get(x => x.ProductID == id);
            if(product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products products)
        {
            if(ModelState.IsValid)
            {
                this.productRepository.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Products product = this.productRepository.Get(x => x.ProductID == id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products product = this.productRepository.Get(x => x.ProductID == id);
            this.productRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}