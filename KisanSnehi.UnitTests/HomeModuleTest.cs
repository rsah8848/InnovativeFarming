using KisanSnehi.Entities;
using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Home;
using KisanSnehi.Services.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KisanSnehi.UnitTests
{
    [TestClass]
    public class HomeModuleTest
    {
        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        IHomeRepository homeRepository;
        IHomeServices homeServices;

        [TestInitialize]
        public void InitializeForTests()
        {
            homeRepository = new HomeRepository(databaseContext);
            homeServices = new HomeServices(homeRepository);
        }

        [TestMethod]
        public async Task AddUser_ReturnsTrueOrNot_Mock()
        {
            Registration user = new Registration();
            user.Name = "ramya bhat";
            user.EmailId = "ram@gmail.com";
            user.Address = "Lig28";
            user.PhoneNo = 9886643442;
            user.Password = "Ramya123*";
            user.SecurityQue = "My pet's name";
            user.Answer = "scooby";
            user.LocationId = 1;

            var mock = new Mock<IHomeRepository>();
            mock.Setup(p => p.AddRegistrationDetails(user)).ReturnsAsync(true);
            homeServices = new HomeServices(mock.Object);
            var result = await homeServices.AddRegistrationDetails(user);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task CheckLogin_ReturnsUserTypeId()
        {
            Registration user = new Registration();
             
            user.EmailId = "ramya2398.rb@gmail.com";
            user.UserTypeId = 4;
            user.Password = "ramya123";
            var value = await homeServices.CheckLogin(user);
            Assert.AreEqual(user.UserTypeId, value);
        }
        [TestMethod]
        public async Task ChangePassword_ReturnsTrueOrNot_Mock()
        {
            Registration user = new Registration();
            user.EmailId = "ram@gmail.com";
            user.Password = "Ramya123*";
            user.SecurityQue = "My pet's name";
            user.Answer = "scooby";
            var mock = new Mock<IHomeRepository>();
            mock.Setup(p => p.ChangePassword(user)).ReturnsAsync(true);
            homeServices = new HomeServices(mock.Object);
            var result = await homeServices.ChangePassword(user);
            Assert.AreEqual(true, result);
        }
    }
}
