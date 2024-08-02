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
    public class FarmerFertilizerGuidanceTests
    {
        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        IFarmerFertilizerRepository Repository;
        IFarmerFertilizerService Services;
        IFarmerGuidanceRepository repository;
        IFarmerGuidanceService service;

        [TestInitialize]
        public void InitializeForTests()
        {
            Repository = new FarmerFertilizerRepository(databaseContext);
            Services = new FarmerFertilizerService(Repository);

            repository = new FarmerGuidanceRepository(databaseContext);
            service = new FarmerGuidanceService(repository);
        }


        [TestMethod]
        public async Task AddFertilizerPurchase_ReturnsTrueOrNot_Mock()
        {
            FertilizerPurchase fertilizerPurchase = new FertilizerPurchase();
            fertilizerPurchase.FertilizerId = 1;
            fertilizerPurchase.FarmerId = 1;
            fertilizerPurchase.FertilizerPurchaseDate = System.DateTime.Now.Date;
            fertilizerPurchase.FertilizerPurchaseQuantity = 10;
            fertilizerPurchase.TraderId = 1;
            fertilizerPurchase.FertilizerBillAmount = 200.0;
           
            var mock = new Mock<IFarmerFertilizerRepository>();
            mock.Setup(p => p.AddFertilizerPurchase(fertilizerPurchase)).ReturnsAsync(true);
            Services = new FarmerFertilizerService(mock.Object);
            var result = await Services.AddFertilizerPurchase(fertilizerPurchase);
            Assert.AreEqual(true, result);
        }


        //[TestMethod]
        //public async Task GetGuidance_ReturnsGuidance_Mock()
        //{
        //    Guidance guidance = new Guidance();
        //    guidance.FromMonth = 5;
        //    guidance.ToMonth = 6;

        //    var mock = new Mock<IFarmerGuidanceRepository>();
        //    mock.Setup(p => p.GetGuidance(guidance)).ReturnsAsync(guidance);
        //}
    }
}
