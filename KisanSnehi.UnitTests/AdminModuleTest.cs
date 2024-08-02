using KisanSnehi.Entities;
using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Admin;
using KisanSnehi.Services.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InnovativeFarming.UnitTests
{
    [TestClass]
    public class AdminModuleTest
    {
        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        IAdminRepository adminRepository;
        IAdminServices adminServices;

        [TestInitialize]
        public void InitializeForTests()
        {
            adminRepository = new AdminRepository(databaseContext);
            adminServices = new AdminServices(adminRepository);
        }
        
        [TestMethod]
        public async Task EditAdmin_ReturnsTrueOrNot_Mock()
        {
            Registration admin = new Registration();
            admin.Name = "ramya bhat";
            admin.EmailId = "ram@gmail.com";
            admin.Address = "Lig28";
            admin.PhoneNo = 9886643442;

            var mock = new Mock<IAdminRepository>();
            mock.Setup(p => p.EditAdminProfile(admin)).ReturnsAsync(true);
            adminServices = new AdminServices(mock.Object);
            var result = await adminServices.EditAdminProfile(admin);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task DeleteAdmin_ReturnsTrueOrNot_Mock()
        {
            Registration admin = new Registration();
            admin.EmailId = "ram@gmail.com";
           
            var mock = new Mock<IAdminRepository>();
            mock.Setup(p => p.DeactivateAdminProfile(admin)).ReturnsAsync(true);
            adminServices = new AdminServices(mock.Object);
            var result = await adminServices.DeactivateAdminProfile(admin);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task ChangePassword_ReturnsTrueOrNot_Mock()
        {
            Registration admin = new Registration();
            admin.EmailId = "ram@gmail.com";
            admin.Password = "Ramya123*";
            admin.SecurityQue = "My pet's name";
            admin.Answer = "scooby";
            var mock = new Mock<IAdminRepository>();
            mock.Setup(p => p.ChangeAdminPassword(admin)).ReturnsAsync(true);
            adminServices = new AdminServices(mock.Object);
            var result = await adminServices.ChangeAdminPassword(admin);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task GetUser_TestValues()
        {
            Registration admin = new Registration();
            admin.EmailId = "ramya2398.rb@gmail.com";
            admin.Name = "ramya";
            admin.Password = "ramya123";
            admin.SecurityQue = "My pet's name";
            admin.Answer = "scooby";
            var value = await adminServices.GetUser(admin.EmailId);
            Assert.AreEqual(admin.Name, value.Name);
        }
        [TestMethod]
        public async Task GetUserById_TestValues()
        {
            Registration admin = new Registration();
            admin.EmailId = "ramya2398.rb@gmail.com";
            admin.Name = "ramya";
            admin.Password = "ramya123";
            admin.SecurityQue = "My pet's name";
            admin.Answer = "scooby";
            var value = await adminServices.GetUsersById(8);
            Assert.AreEqual(admin.EmailId, value.EmailId);
        }
        [TestMethod]
        public async Task ResolveFeedback_ReturnsTrueOrNot_Mock()
        {
            Feedback feedback = new Feedback();
            feedback.FeedbackId = 1;
            var mock = new Mock<IAdminRepository>();
            mock.Setup(p => p.ResolveFeedback(feedback.FeedbackId)).ReturnsAsync(true);
            adminServices = new AdminServices(mock.Object);
            var result = await adminServices.ResolveFeedback(feedback.FeedbackId);
            Assert.AreEqual(true, result);
        }
    }
}
