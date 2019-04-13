using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreOnlineApparelStoreAdminPortal.Controllers
{
    public class ProductController : Controller
    {
        DbContextClass context;
        public ProductController(DbContextClass _context)
        {
            context = _context;
        }
        public ViewResult Index()
        {
            var pro = context.Products.ToList();
            return View(pro);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.category = new SelectList(context.Categories, "CategoryId", "CategoryName");
            ViewBag.vendor = new SelectList(context.Vendors, "VendorId", "VendorName");
            ViewBag.brand = new SelectList(context.Brands, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("ProductName","ProductPrice","ProductQuantity","ProductSize")]Product c)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product pro = context.Products.Find(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product P1)
        {
            Product p = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            context.Products.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product p = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            ViewBag.category = new SelectList(context.Categories, "CategoryId", "CategoryName",p.CategoryId);
            ViewBag.vendor = new SelectList(context.Vendors, "VendorId", "VendorName",p.VendorId);
            ViewBag.brand = new SelectList(context.Brands, "BrandId", "BrandName", p.BrandId);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product p1)
        {
            Product p = context.Products.Where(x => x.ProductId == p1.ProductId).SingleOrDefault();
            context.Entry(p).CurrentValues.SetValues(p1);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            Product p = context.Products.Where(x => x.ProductId== id).SingleOrDefault();
            return View(p);
        }

    }
}