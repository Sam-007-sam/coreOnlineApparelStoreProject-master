using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreOnlineApparelStoreAdminPortal.Controllers
{
    public class BrandController : Controller
    {
        DbContextClass context;
        public BrandController(DbContextClass _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var ind = context.Brands.ToList();
            return View(ind);
        }
        [HttpGet]
        public ViewResult Create()//view not created
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("BrandName")]Brand B)
        {
            if (ModelState.IsValid)
            {
                context.Brands.Add(B);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(B);
           
        }
        public ActionResult Delete(int id)
        {
            Brand ban = context.Brands.Find(id);
            return View(ban);
        }
        [HttpPost]
        public ActionResult Delete(int id, Brand b1)
        {
            Brand b = context.Brands.Where(x => x.BrandId == id).SingleOrDefault();
            context.Brands.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Brand ban = context.Brands.Where(x => x.BrandId == id).SingleOrDefault();
            return View(ban);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand b1)
        {
            Brand b = context.Brands.Where(x => x.BrandId == b1.BrandId).SingleOrDefault();
            context.Entry(b).CurrentValues.SetValues(b1);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            Brand b = context.Brands.Where(x => x.BrandId == id).SingleOrDefault();
            return View(b);
        }
    }
}