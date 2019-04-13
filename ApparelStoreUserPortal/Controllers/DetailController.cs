using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreUserPortal.Helper;
using ApparelStoreUserPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApparelStoreUserPortal.Controllers
{
    public class DetailController : Controller
    {
        private readonly OnlineApparelStoreDbContext context;
        public DetailController(OnlineApparelStoreDbContext _context)
        {
            context = _context;
        }
        [Route("index")]
        public IActionResult Index()
         {
                var products = context.Products.ToList();
                return View(products);
         }
        
        [Route("display/{id}")]
        public IActionResult Display(int id)
        {
            Products products = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            var product = context.Products.Find(id);
            ViewBag.vendorName = context.Vendors.Find(product.VendorId);
            ViewBag.CategoryName = context.Categories.Find(product.CategoryId);
            ViewBag.BrandName = context.Brands.Find(product.BrandId);
            return View(products);                   
                        
        }
    }
}
