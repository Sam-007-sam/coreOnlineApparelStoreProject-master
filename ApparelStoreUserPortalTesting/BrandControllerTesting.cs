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
    public class BrandControllerTesting
    {
        private OnlineApparelStoreDbContext context;

        public static DbContextOptions<OnlineApparelStoreDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502; Initial Catalog=OnlineApparelStoreDb;Integrated Security=True;";
        static BrandControllerTesting()
        {
            dbContextOptions = new DbContextOptionsBuilder<OnlineApparelStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public BrandControllerTesting()
        {
            context = new OnlineApparelStoreDbContext(dbContextOptions);
        }
        [Fact]
        public void Task_Index_Return_ViewResult()
        {
            var controller = new BrandController(context);

            IActionResult data = controller.Display();
            Assert.IsType<ViewResult>(data);
        }

        [Fact]
        public void Task_ProductDisplay_Return_ViewResult()
        {
            var controller = new BrandController(context);
            var BrandId = 1;
            IActionResult data = controller.DisplayByBrand(BrandId);
            Assert.IsType<ViewResult>(data);
        }

    }
}
