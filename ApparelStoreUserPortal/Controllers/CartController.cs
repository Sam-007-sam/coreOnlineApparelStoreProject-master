using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreUserPortal.Models;
using Microsoft.AspNetCore.Mvc;
using ApparelStoreUserPortal.Helper;
using Microsoft.AspNetCore.Http;

namespace ApparelStoreUserPortal.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly OnlineApparelStoreDbContext context;
        public CartController(OnlineApparelStoreDbContext _context)
        {
            context = _context;
        }
        [Route("index")] 
       public IActionResult Index()
        {         
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int i = 0;
            if (cart != null)
            {
                foreach(var item in cart)
                {
                    i++;
                }
                if(i != 0)
                {
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Products.ProductPrice * item.ItemQuantity);
                    if (SessionHelper.GetObjectFromJson<Customers>(HttpContext.Session, "cus") == null)
                        ViewBag.i = 0;
                    else
                        ViewBag.i = 1;
                    return View();
                }              
            }
            return View("Goback");
        }
       
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if((SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart")==null))
                {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Products = context.Products.Find(id), ItemQuantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else{
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index!=-1)
                {
                    cart[index].ItemQuantity++;
                }
                else
                {
                    cart.Add(new Item { Products = context.Products.Find(id), ItemQuantity=1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index","Home");
        }    

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            int j = int.Parse(HttpContext.Session.GetString("cartitem"));
            int i = 0;
            foreach(var item in cart)
            {
                i++;
            }          
                if (i != 0) 
                {
                              
                    j--; 
                    HttpContext.Session.SetString("cartitem", j.ToString());
                }
                else
                 {
                    HttpContext.Session.Remove("cartitem");
                    return View("Goback");
                 }

            return RedirectToAction("index");
            
        }
        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i=0;i<cart.Count;i++)
            {
                if(cart[i].Products.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            int i = 0;
            ViewBag.i = i;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Products.ProductPrice * item.ItemQuantity);          
            Customers cus = SessionHelper.GetObjectFromJson<Customers>(HttpContext.Session, "cus");
            ViewBag.Customers = cus;
            TempData["total"] = ViewBag.total;
            return View();        
        }

        [HttpPost]
        public IActionResult Checkout(Customers customers)
        {             
            var customer = context.Customers.Where(x => x.Email ==customers.Email).SingleOrDefault();
            customer.CustomerFirstName = customers.CustomerFirstName;
            customer.CustomerLastName = customers.CustomerLastName;
            customer.UserName = customers.UserName;
            customer.Gender = customers.Gender;
            customer.Email = customers.Email;
            customer.PhoneNumber = customers.PhoneNumber;
            customer.Country = customers.Country;
            customer.State = customers.State;
            customer.ZipCode = customers.ZipCode;
            customer.Address = customers.Address;
            customer.Address2 = customers.Address2;
            customer.SameAddress = customers.SameAddress;
            customer.AlternatePhoneNumber = customers.AlternatePhoneNumber;
            customer.Country2 = customers.Country2;
            customer.State2 = customers.State2;
            customer.ZipCode2 = customers.ZipCode2;

            context.SaveChanges();
            var amount = TempData["total"];
            Orders orders = new Orders()
            {
                OrderAmount = Convert.ToSingle(amount),
                OrderDate=DateTime.Now,
              CustomerId=customer.CustomerId
            };
            context.Orders.Add(orders);
            context.SaveChanges();
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            List<OrderProducts> orderProducts = new List<OrderProducts>();
            for(int i=0;i<cart.Count;i++)
            {
                OrderProducts orderProduct = new OrderProducts()
                {
                    OrderId=orders.OrderId,
                    ProductId=cart[i].Products.ProductId,
                    Quantity=cart[i].ItemQuantity
                };
                orderProducts.Add(orderProduct);
            }
            orderProducts.ForEach(n => context.OrderProducts.Add(n));
            context.SaveChanges();
            TempData["cust"] = customer.CustomerId;
           return RedirectToAction("Status", "cart");
        
        }

        [Route("Status")]
        public IActionResult Status()
        {
            int CustId = int.Parse(TempData["cust"].ToString());
            Customers customers = context.Customers.Where(x => x.CustomerId == CustId).SingleOrDefault();
            ViewBag.Customers = customers;
          
            //int custId = int.Parse(TempData["cust"].ToString());
            //Orders ord = context.Orders.Where(x => x.CustomerId == custId).SingleOrDefault();
            //ViewBag.order = ord;

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            foreach(var item in cart)
            {
                Products pro = context.Products.Find(item.Products.ProductId);
                pro.ProductQuantity = pro.ProductQuantity - item.ItemQuantity;
                context.SaveChanges();
            }
            float total= cart.Sum(item => item.Products.ProductPrice * item.ItemQuantity);
            ViewBag.total = total;
            ViewBag.discount = (20 * ViewBag.total) / 100;
            cart = null;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            HttpContext.Session.Remove("cartitem");
            return View();
        }

        [Route("Addbutton/{id}")]
        public IActionResult Addbutton(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].ItemQuantity++;
            }
            else
            {
                cart.Add(new Item { Products = context.Products.Find(id), ItemQuantity = 1 });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("index");
        }    
        
        [Route("Subtractbutton/{id}")]
        public IActionResult Subratctbutton(int id)
        {
        List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        int index = isExist(id);
        if (index != -1)
        {
            if (cart[index].ItemQuantity != 1)
            {
                cart[index].ItemQuantity--;
            }
            else
                return RedirectToAction("Remove", "Cart", new {@id = id });

        }
        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        return RedirectToAction("Index");
    }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            if (username != null && password != null)
            {

                var cus = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                if (cus != null && password.Equals(cus.Password))
                {

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cus", cus);
                    HttpContext.Session.SetString("cusid", cus.CustomerId.ToString());
                    HttpContext.Session.SetString("name", cus.CustomerFirstName + " " + cus.CustomerLastName);

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);

                    HttpContext.Session.Remove("cartitem");

                    return RedirectToAction("index", "home");


                }
                else
                {
                    ViewBag.Error = "Register Email First";

                }



            }
            return RedirectToAction("Index");

        }
        [Route("Login1")]
        [HttpPost]
        public IActionResult Login1(string username, string password)
        {

            if (username != null && password != null)
            {

                var cus = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                if (cus != null && password.Equals(cus.Password))
                {

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cus", cus);


                    HttpContext.Session.SetString("cusid", cus.CustomerId.ToString());
                    HttpContext.Session.SetString("name", cus.CustomerFirstName + " " + cus.CustomerLastName);
                    
                    return RedirectToAction("Checkout");


                }
                else
                {
                    ViewBag.Error = "Register Email First";

                }



            }
            return RedirectToAction("Index");

        }

        [Route("register")]
        [HttpPost]
        public IActionResult Regiter(string username, string password, string firstname, string lastname)
        {

            if (username != null && password != null)
            {

                var cus = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                if (cus != null)
                {

                    ViewBag.Error = "Alredy register";


                }
                else
                {
                    Customers c = new Customers();
                    c.Email = username;
                    c.Password = password;

                    c.CustomerFirstName = firstname;
                    c.CustomerLastName = lastname;
                    context.Customers.Add(c);
                    context.SaveChanges();
                    Customers cus1 = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cus", cus1);

                    HttpContext.Session.Remove("cartitem");
                    HttpContext.Session.SetString("name", c.CustomerFirstName + " " + c.CustomerLastName);
                    HttpContext.Session.SetString("cusid", cus1.CustomerId.ToString());

                   
                    return RedirectToAction("index", "home");


                }

            }
            return RedirectToAction("Index");



        }
        [Route("register1")]
        [HttpPost]
        public IActionResult Regiter1(string username, string password, string firstname, string lastname)
        {

            if (username != null && password != null)
            {

                var cus = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                if (cus != null)
                {

                    ViewBag.Error = "Alredy register";


                }
                else
                {
                    Customers c = new Customers();
                    c.Email = username;
                    c.Password = password;

                    c.CustomerFirstName = firstname;
                    c.CustomerLastName = lastname;
                    context.Customers.Add(c);
                    context.SaveChanges();
                    Customers cus1 = context.Customers.Where(x => x.Email == username).SingleOrDefault();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cus", cus1);
                    HttpContext.Session.Remove("cartitem");
                    HttpContext.Session.SetString("name", c.CustomerFirstName + " " + c.CustomerLastName);
                    HttpContext.Session.SetString("cusid", cus1.CustomerId.ToString());
                    
                    return RedirectToAction("checkout");

                }

            }
            return RedirectToAction("Index");



        }
        [Route("Search")]
        [HttpPost]
        public IActionResult Search(string search)
        {
            List<Products> prod = new List<Products>();
            var product = context.Products.Where(x => x.ProductName == search).ToList();
            if (context.Brands.Where(x => x.BrandName == search).SingleOrDefault() != null)
            {
                Brands b = context.Brands.Where(x => x.BrandName == search).SingleOrDefault();
                var brand = context.Products.Where(x => x.BrandId == b.BrandId).ToList();
                foreach (var item in brand)
                {
                    prod.Add(item);

                }
            }
            if(context.Categories.Where(x => x.CategoryName == search).SingleOrDefault() != null) {
                Categories c = context.Categories.Where(x => x.CategoryName == search).SingleOrDefault();
                var category = context.Products.Where(x => x.CategoryId == c.CategoryId).ToList();
                foreach (var item in category)
                {
                    prod.Add(item);

                }
            }
            
            foreach(var item in product)
            {
                prod.Add(item);

            }
            
           
            return View(prod);
        }

    }
}