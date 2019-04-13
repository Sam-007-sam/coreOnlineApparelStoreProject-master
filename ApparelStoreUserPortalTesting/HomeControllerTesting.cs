using ApparelStoreUserPortal.Controllers;
using ApparelStoreUserPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApparelStoreUserPortalTesting
{
    public class HomeControllerTesting
    {
        private OnlineApparelStoreDbContext context;

        public static DbContextOptions<OnlineApparelStoreDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502; Initial Catalog=OnlineApparelStoreDb;Integrated Security=True;";
        static HomeControllerTesting()
        {
            dbContextOptions = new DbContextOptionsBuilder<OnlineApparelStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public HomeControllerTesting()
        {
            context = new OnlineApparelStoreDbContext(dbContextOptions);
        }
        [Fact]
        public void Task_Index_Return_ViewResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new HomeController(context);

                var data = controller.Index();

                Assert.Null(data);

                var viewResult = Assert.IsType<ViewResult>(data);
            });

        }
        [Fact]
        public void Task_logout_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new HomeController(context);
                var data = controller.logout();
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_UserProfile_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new HomeController(context);
                var data = controller.userProfile();
                Assert.NotNull(data);
                Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_EditProfile_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller= new HomeController(context);
                var customerId = 6;
                var customer = new Customers()
                {
                    CustomerFirstName = "Eshika",
                    CustomerLastName = "Saxena",
                    UserName = "Echi",
                    Email = "Eshikasaxena1402@gmail.com",
                    Address = "Muradabad",
                    Address2 = "Muradabad",
                    Country = "India",
                    Country2 = "India",
                    State2 = "UP",
                    ZipCode = 754321,
                    ZipCode2 = 754321,
                    SameAddress = true,
                    PhoneNumber = 7599437873,
                    AlternatePhoneNumber = 9411971385,
                    Gender = "Female",
                    Password = "Eshika007",
                    State = "Up"
                };
                var data = controller.EditProfile();
                Assert.NotNull(data);
            });
        }
        [Fact]
        public void Task_CustomerHistory_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new HomeController(context);
                var data = controller.CustomerHistory();
                Assert.IsType<ViewResult>(data);
            });
        }
        [Fact]
        public void Task_OrderDetails_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new HomeController(context);
                var orderId = 7;
                var data = controller.orderDetails(orderId);
                Assert.IsType<ViewResult>(data);
            });
        }
    }
}
