using coreOnlineApparelStoreAdminPortal.Controllers;
using coreOnlineApparelStoreAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace AdminPortalTesting
{
    public class AccountTest
    {
        AccountController controller;
        DbContextClass context;
        public AccountTest()
        {
            controller = new AccountController(context);         
        }
        [Trait("Account", "Index")]
        [Fact(DisplayName ="AccountIndex")]
        public void Test1()
        {
            //Arrange
            //Act
            IActionResult result =controller.Index();
            //Assert
            Assert.NotNull(result);
        }
       
        [Trait("Account", "Login")]
        [Fact(DisplayName = "AccountLogin")]
       
        public void Test2()
        {               
            Assert.Throws<NullReferenceException>(() => {
                controller.Login("Saxena@gmail.com", "Saxena");
            });        
        }
        [Trait("Account", "Logout")]
        [Fact(DisplayName = "AccountLogout")]
        public void Test3()
        {
            Assert.Throws<NullReferenceException>(() => {
                controller.Logout();
            });
        }
    }
}
