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
    public class CategoryControllerTesting
    {
        private OnlineApparelStoreDbContext context;

        public static DbContextOptions<OnlineApparelStoreDbContext> dbContextOptions { get; set; }
        public static string connectionString = "Data Source=TRD-502; Initial Catalog=OnlineApparelStoreDb;Integrated Security=True;";
        static CategoryControllerTesting()
        {
            dbContextOptions = new DbContextOptionsBuilder<OnlineApparelStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public CategoryControllerTesting()
        {
            context = new OnlineApparelStoreDbContext(dbContextOptions);
        }
        [Fact]
        public void Task_CategoryIndex_Return_ViewResult()
        {
            var controller = new CategoryController(context);

            IActionResult data = controller.Display();
            Assert.IsType<ViewResult>(data);
        }

        [Fact]
        public void Task_CategoryuProductDisplay_Return_ViewResult()
        {
            var controller = new CategoryController(context);
            var CategoryId = 1;
            IActionResult data = controller.DisplayByCategory(CategoryId);
            Assert.IsType<ViewResult>(data);
        }
    }
}
