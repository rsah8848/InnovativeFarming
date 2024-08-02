using KisanSnehi.Entities;
using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Farmer;
using KisanSnehi.Services.Farmer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace KisanSnehi.UnitTests
{

    [TestClass]
    public class FarmerProfileTest
    {


        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        IFarmerProfileRepository Repository;
        IFarmerProfileServices Services;

        [TestInitialize]
        public void InitializeForTests()
        {
            Repository = new FarmerProfileRepository(databaseContext);
            Services = new FarmerProfileServices(Repository);
        }






        [TestMethod]
        public async Task UpdateFarmerProfile_ReturnsTrueOrNot_Mock()
        {
            Registration admin = new Registration();
            admin.Name = "ramya bhat";
            admin.Address = "Lig28";
            admin.PhoneNo = 9886643442;
            admin.LocationId = 1;

            var mock = new Mock<IFarmerProfileRepository>();
            mock.Setup(p => p.UpdateFarmerProfile(admin)).ReturnsAsync(true);
            Services = new FarmerProfileServices(mock.Object);
            var result = await Services.UpdateFarmerProfile(admin);
            Assert.AreEqual(true, result);
        }

        

        [TestMethod]
        public async Task AddCrop_ReturnsTrueOrNot_Mock()
        {
            Crop crop = new Crop();
            crop.CropName = "Rice";
            crop.CropPrice = 245.80;
            crop.CropQuantity = 10;
            crop.CropDesc = "rice description..";
            var mock = new Mock<IFarmerProfileRepository>();
            mock.Setup(p => p.AddCrop(crop)).ReturnsAsync(true);
            Services = new FarmerProfileServices(mock.Object);
            var result = await Services.AddCrop(crop);
            Assert.AreEqual(true, result);
        }

        
        [TestMethod]
        public async Task UpdateCropDetails_ReturnsTrueOrNot_Mock() 
        {
            Crop crop = new Crop();
            crop.CropId = 1;
            crop.CropName = "Rice";
            crop.CropPrice = 245.80;
            crop.CropQuantity = 10;
            crop.CropDesc = "rice description..";
            crop.Image = "abc.jpg";
            var mock = new Mock<IFarmerProfileRepository>();
            mock.Setup(p => p.UpdateCropDetails(crop)).ReturnsAsync(true);
            Services = new FarmerProfileServices(mock.Object);
            var result = await Services.UpdateCropDetails(crop);
            Assert.AreEqual(true, result);

        }


        [TestMethod]
        public async Task DeleteCrop()
        {
            var mock = new Mock<IFarmerProfileRepository>();
            mock.Setup(p => p.DeleteCrop(1)).ReturnsAsync(true);
            Services = new FarmerProfileServices(mock.Object);
            var result = await Services.DeleteCrop(1);
            Assert.AreEqual(true, result);
        }

        
        

        
    }
}
