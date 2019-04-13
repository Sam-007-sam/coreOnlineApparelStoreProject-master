using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreUserPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApparelStoreUserPortal.Controllers
{
    public class BrandController : Controller
    {        
        private readonly OnlineApparelStoreDbContext context;
        public BrandController(OnlineApparelStoreDbContext _context)
        {
            context = _context;
        }
        public IActionResult Display()
        {
            var brands = context.Brands.ToList();
            return View(brands);
        }
        public IActionResult DisplayByBrand(int id)
        {
            var products = context.Products.Where(x => x.BrandId == id).ToList();
            return View(products);
        }
    }
}