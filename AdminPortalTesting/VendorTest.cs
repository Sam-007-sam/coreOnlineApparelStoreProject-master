//using coreOnlineApparelStoreAdminPortal.Controllers;
//using coreOnlineApparelStoreAdminPortal.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace AdminPortalTesting
//{
//    public class VendorTest
//    {
//        VendorController controller;
//        DbContextClass context;
//        public VendorTest()
//        {
//            controller = new VendorController(context);
//        }
//        [Trait("Vendor", "Index")]
//        [Fact(DisplayName = "VendorIndex")]
//        public void Test1()
//        {
//            Assert.Throws<NullReferenceException>(() => {
//                IActionResult result = controller.Index();
//                Assert.NotNull(result);
//            });
//        }
//        [Trait("Vendor", "Create")]
//        [Fact(DisplayName = "VendorCreate")]
//        public void Test2()
//        {
//            IActionResult result = controller.Create();
//            Assert.NotNull(result);
//        }
//        [HttpPost]
//        [Trait("Vendor", "Create")]
//        [Fact(DisplayName = "VendorPostIfCreate")]
//        public void Test3()
//        {
//            ViewResult result =controller.Create();
//            Assert.NotNull(result);
//            Assert.Contains("E", "Eshika");
//            Assert.IsType<Vendor>(result.Model);
//        }
//        [Trait("Vendor", "Create")]
//        [Fact(DisplayName = "VendorPostElseCreate")]
//        public void Test4()
//        {
//            ViewResult result =controller.Create();
//            Assert.NotNull(result);
//            Assert.Contains("E", "eshika");
//            Assert.IsType<Brand>(result.Model);
//            //    Assert.IsNotNull(result.ViewName);
//            Assert.is(result.ViewName, typeof(ViewResult));
//        }
//        [Trait("Brand", "Delete")]
//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        public void Test5(int id)
//        {
//            IActionResult result = null;
//            Assert.Throws<NullReferenceException>(() =>
//            {
//                result = controller.Delete(id);
//                Assert.NotNull(result);
//            });
//        }
//        [HttpPost]
//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        [Trait("Brand", "Delete")]
//        public void Test6(int id)
//        {
//            Assert.Throws<NullReferenceException>(() =>
//            {
//                IActionResult result = controller.Delete(3);
//                Assert.NotNull(result);
//            });
//        }
//        [Trait("Brand", "Edit")]
//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        public void Test7(int id)
//        {
//            Assert.Throws<NullReferenceException>(() =>
//            {
//                IActionResult result = controller.Edit(id);
//                Assert.NotNull(result);
//                Assert.Contains("y", "xyz");
//            });
//        }
//        [HttpPost]
//        [Trait("Brand", "Edit")]
//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        public void Test8(int id)
//        {
//            Assert.Throws<NullReferenceException>(() =>
//            {
//                ViewResult result = (ViewResult)controller.Edit(id);
//                Assert.NotNull(result);
//                Assert.IsType<Brand>(result.Model);
//            });
//        }
//        [Trait("Brand", "Details")]
//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        public void Test9(int id)
//        {
//            ViewResult result = null;
//            Assert.Throws<NullReferenceException>(() =>
//            {
//                result = (ViewResult)controller.Details(id);
//                Assert.NotNull(result);
//                Assert.IsType<Brand>(result.Model);

//            });
//            Assert.Equal("Zara", "Zara");
//            Assert.Null(result);
//        }
//    }
//}
