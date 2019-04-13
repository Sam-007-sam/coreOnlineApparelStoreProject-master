using ApparelStoreUserPortal.Controllers;
using ApparelStoreUserPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreApparelStoreUserPortalTesting
{
    public class CartControllerTesting
    {
        private OnlineApparelStoreDbContext context;

        public static DbContextOptions<OnlineApparelStoreDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502; Initial Catalog=OnlineApparelStoreDb;Integrated Security=True;";
        static CartControllerTesting()
        {
            dbContextOptions = new DbContextOptionsBuilder<OnlineApparelStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public CartControllerTesting()
        {
            context = new OnlineApparelStoreDbContext(dbContextOptions);
        }
        [Fact]
        public void Task_Index_Return_ViewResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);

                var data = controller.Index();

                Assert.Null(data);

                var viewResult = Assert.IsType<ViewResult>(data);
            });

        }
        [Fact]
        public void Task_Checkout_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
            var CustomerId = 1;
            var customer = new Customers()
            {
                CustomerId = 1,
                CustomerFirstName = "Eshika",
                CustomerLastName = "Saxena",
                UserName = "eshu",
                Password = "eshu",
                Email = "eshika@gmail.com",
                Address = "Alpha-1, gREATER nOIDA",
                Address2 = "Alpha-1, gREATER nOIDA",
                State = "Uttar Pradesh",
                State2 = "Uttar Pradesh",
                Country = "India",
                Country2 = "India",
                PhoneNumber = 7599437873,
                AlternatePhoneNumber = 7599437873,
                ZipCode = 1234,
                ZipCode2 = 1234,
                Gender = "Female"
            };
            var data = controller.Checkout(customer);
            Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_remove_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1003;
                var data = controller.Remove(Id);
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_Login_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var CustomerEmail = "shivani@user.com";
                var CustomerPassword = "123456";
                var data = controller.Login(CustomerEmail, CustomerPassword);
                Assert.NotNull(data);
                Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_Register_Return_View()
        {
            var controller = new CartController(context);
            var CustomerFirstName = "Eshika";
            var CustomerLastName = "Saxena";
            var CustomerEmail = "eshika@gmail.com";
            var CustomerPassword = "eshu";
            var data = controller.Regiter(CustomerEmail, CustomerPassword, CustomerFirstName, CustomerLastName);
            Assert.NotNull(data);
        }


        [Fact]
        public void Task_Status_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var data = controller.Status();
                Assert.IsType<ViewResult>(data);
            });
        }
    }
}
