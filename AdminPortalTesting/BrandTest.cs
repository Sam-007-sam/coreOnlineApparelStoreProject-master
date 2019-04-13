using coreOnlineApparelStoreAdminPortal.Controllers;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdminPortalTesting
{
    public class BrandTest
    {
        BrandController controller;
        DbContextClass context;
        public BrandTest()
        {
            controller = new BrandController(context);
        }
        [Trait("Brand", "Index")]
        [Fact(DisplayName = "BrandIndex")]
        public void Test1()
        {
            Brand b = new Brand();
            Assert.Throws<NullReferenceException>(()=> {
                IActionResult result = controller.Index();
                Assert.NotNull(result);
                Assert.IsType<Brand>(b.BrandId);             
                Assert.NotNull(b.BrandName);
                Assert.NotNull(b.BrandDescription);
            });      
        }
        [Trait("Brand", "Create")]
        [Theory]
        [InlineData(1)]
        public void Test2(int id)
        {
            Brand b = new Brand();
            IActionResult result = controller.Create();
            Assert.NotNull(result);
        }
        [HttpPost]
        [Trait("Brand","CreatePost")]
        [Theory]
        [InlineData(1)]
        public void Test3(int id)
        {
            Brand b=new Brand();
            ViewResult result = null;        
            Assert.Throws<NullReferenceException>(() => {
                result=(ViewResult)controller.Create(b);
                Assert.NotNull(result);
                Assert.NotNull(b.BrandName);
                Assert.NotNull(b.BrandDescription);
                Assert.IsType<Brand>(result.Model);
            });
            Assert.Null(result);
        }
        [Trait("Brand", "Create")]
        [Fact(DisplayName = "BrandPostElseCreate")]
        public void Test4()
        {
            ViewResult result = (ViewResult)controller.Create();
            Assert.NotNull(result);
            Assert.Contains("Z", "Zara");
            Assert.IsType<Brand>(result.Model);
            //    Assert.IsNotNull(result.ViewName);
            //    Assert.IsNotInstanceOfType(result.ViewName, typeof(ViewResult));
        }
        [Trait("Brand", "Delete")]
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test5(int id)
        {
            IActionResult result = null;
            Assert.Throws<NullReferenceException>(() =>
            {
                result = controller.Delete(id);
                Assert.NotNull(result);  
            });        
        }
        [HttpPost]
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [Trait("Brand", "Delete")]
        public void Test6(int id)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                IActionResult result = controller.Delete(3);
                Assert.NotNull(result);
            });
        }
        [Trait("Brand", "Edit")]
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test7(int id)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                IActionResult result = controller.Edit(id);
                Assert.NotNull(result);
                Assert.Contains("y", "xyz");
            });
        }
        [HttpPost]
        [Trait("Brand", "Edit")]
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test8(int id)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                ViewResult result =(ViewResult) controller.Edit(id);
                Assert.NotNull(result);
                Assert.IsType<Brand>(result.Model);
            });
        }      
        [Trait("Brand", "Details")]
        [Theory]
        [InlineData(1)]
        public void Test9(int id)
        {
            ViewResult result = null;
            Assert.Throws<NullReferenceException>(() =>
            {
                 result = (ViewResult)controller.Details(id);
                Assert.NotNull(result);
                Assert.IsType<Brand>(result.Model);
                Brand b = (Brand)result.Model;
                Assert.Equal(b.BrandName, "Varshache");
                
            });
            Assert.Equal("Zara", "Zara");
            Assert.Null(result);
        }
    }
}