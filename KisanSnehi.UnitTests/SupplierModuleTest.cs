using System;
using System.Collections.Generic;
using System.Text;
using KisanSnehi.Entities;
using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Supplier;
using KisanSnehi.Services.Supplier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace KisanSnehi.UnitTests
{
    [TestClass]
    public class SupplierModuleTest
    {
        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        ISupplierRepository Repository;
        ISupplierServices Services;

        [TestInitialize]
        public void InitializeForTests()
        {
            Repository = new SupplierRepository(databaseContext);
            Services = new SupplierServices(Repository);
        }


        [TestMethod]
        public async Task GetUser_ReturnsTrueOrNot_Mock()
        {
            Registration supplier = new Registration();
            supplier.EmailId = "arpitasur@gmail.com";
            supplier.Name = "Arpita Sur";
            supplier.Password = "Arpita#123";
            supplier.SecurityQue = "My pet's name";
            supplier.Answer = "Hojo";

            var result = await Services.GetSupplier(supplier.EmailId);
            Assert.AreEqual(supplier.Name, result.Name);
        }

        [TestMethod]
        public async Task EditSupplierProfile_ReturnsTrueOrNot_Mock()
        {
            Registration supplier = new Registration();
            supplier.Name = "Arpita Sur";
            supplier.Address = "CTPS Colony";
            supplier.PhoneNo = 9998887770;
            supplier.LocationId = 1;

            var mock = new Mock<ISupplierRepository>();
            mock.Setup(p => p.EditSupplierProfile(supplier)).ReturnsAsync(true);
            Services = new SupplierServices(mock.Object);
            var result = await Services.EditSupplierProfile(supplier);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task DeleteTrader_ReturnsTrueOrNot_Mock()
        {
            Registration supplier = new Registration();
            supplier.EmailId = "arpitasur@gmail.com";

            var mock = new Mock<ISupplierRepository>();
            mock.Setup(p => p.DeactivateSupplierProfile(supplier)).ReturnsAsync(true);
            Services = new SupplierServices(mock.Object);
            var result = await Services.DeactivateSupplierProfile(supplier);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public async Task ChangePassword_ReturnsTrueOrNot_Mock()
        {
            Registration supplier = new Registration();
            supplier.EmailId = "arpitasur@gmail.com";
            supplier.Password = "Arpita#123";
            supplier.SecurityQue = "My pet's name";
            supplier.Answer = "Hojo";

            var mock = new Mock<ISupplierRepository>();
            mock.Setup(p => p.ChangeSupplierPassword(supplier)).ReturnsAsync(true);
            Services = new SupplierServices(mock.Object);
            var result = await Services.ChangeSupplierPassword(supplier);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task AddCropPurchase_ReturnsTrueOrNot_Mock()
        {
            CropPurchase cropPurchase = new CropPurchase();
            cropPurchase.CropId = 3;
            cropPurchase.SupplierId = 10;
            cropPurchase.CropPurchaseDate = System.DateTime.Now.Date;
            cropPurchase.CropPurchaseQuantity = 5;
            cropPurchase.FarmerId = 5;
            cropPurchase.CropBillAmount = 100.0;

            var mock = new Mock<ISupplierRepository>();
            mock.Setup(p => p.AddCropPurchase(cropPurchase)).ReturnsAsync(true);
            Services = new SupplierServices(mock.Object);
            var result = await Services.AddCropPurchase(cropPurchase);
            Assert.AreEqual(true, result);
        }
    }
}
