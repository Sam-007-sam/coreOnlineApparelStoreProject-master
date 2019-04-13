using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreOnlineApparelStoreAdminPortal.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        DbContextClass context;
        public AccountController(DbContextClass _context)
        {
            context = _context;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]
        [HttpGet]
        public IActionResult Index()
        {           
            return View();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Admin ad=context.Admins.Where(x => x.Email == username).SingleOrDefault();
            if (username != null && password != null && ad!=null && password.Equals(ad.Password))
            {
                HttpContext.Session.SetString("uname",ad.FirstName +" "+ad.LastName);
                return View("Home");
            }
            else
            {
                ViewBag.Error="Invalid Credentials";
                return View("Index");
            }
            
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");         
        }
        
    }
}