using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreOnlineApparelStoreAdminPortal.Controllers
{
    public class CategoryController : Controller
    {

        DbContextClass context;
        public CategoryController(DbContextClass _context)
        {
            context = _context;
        }
        public ViewResult Index()
        {
            var cat = context.Categories.ToList();
            return View(cat);
        }
        [HttpGet]
        public ViewResult Create()//view not created
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("CategoryName")]Category C)
        {
            if(ModelState.IsValid)
            {
                context.Categories.Add(C);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(C);
        }
        public ActionResult Delete(int id)
        {
            Category cat = context.Categories.Find(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category c1)
        {
            Category c = context.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            context.Categories.Remove(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category cat = context.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category c1)
        {
            Category c = context.Categories.Where(x => x.CategoryId == c1.CategoryId).SingleOrDefault();
            context.Entry(c).CurrentValues.SetValues(c1);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            Category c = context.Categories.Where(x => x.CategoryId== id).SingleOrDefault();
            return View(c);
        }
    }
}