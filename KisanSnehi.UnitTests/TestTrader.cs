using System.Threading.Tasks;
using KisanSnehi.Entities;
using KisanSnehi.Repositories;
using KisanSnehi.Repositories.Trader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using KisanSnehi.Services.Trader;

namespace KisanSnehi.UnitTests
{
    [TestClass]
    public class TestTrader
    {
        KisanSnehiDBContext databaseContext = new KisanSnehiDBContext();

        ITraderRepository traderRepository;
        ITraderServices traderServices;

        [TestInitialize]
        public void InitializeForTests()
        {
            traderRepository = new TraderRepository(databaseContext);
            traderServices = new TraderServices(traderRepository);
        }

        [TestMethod]
        public async Task GetUser_TestValues()
        {
            Registration trader = new Registration();
            trader.EmailId = "jambagi@gmail.com";
            trader.Name = "anusha";
            trader.Password = "Anush@123";
            trader.SecurityQue = "My pet's name";
            trader.Answer = "jimmy";
            var value = await traderServices.GetUser(trader.EmailId);
            Assert.AreEqual(trader.Name, value.Name);
        }

        [TestMethod]
        public async Task UpdateTraderProfile_ReturnsTrueOrNot_Mock()
        {
            Registration trader = new Registration();
            trader.Name = "anusha";
            trader.EmailId = "jambagi@gmail.com";
            trader.Address = "mysore";
            trader.PhoneNo = 9123456789;

            var mock = new Mock<ITraderRepository>();
            mock.Setup(p => p.UpdateTraderProfile(trader)).ReturnsAsync(true);
            traderServices = new TraderServices(mock.Object);
            var result = await traderServices.UpdateTraderProfile(trader);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task DeleteTraderProfile_ReturnsTrueOrNot_Mock()
        {
            Registration trader = new Registration();
            trader.EmailId = "jambagi@gmail.com";

            var mock = new Mock<ITraderRepository>();
            mock.Setup(p => p.DeleteTraderProfile(trader)).ReturnsAsync(true);
            traderServices = new TraderServices(mock.Object);
            var result = await traderServices.DeleteTraderProfile(trader);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task UpdateTraderPassword_ReturnsTrueOrNot_Mock()
        {
            Registration trader = new Registration();
            trader.EmailId = "jambagi@gmail.com";
            trader.Password = "Anusha@123";
            trader.SecurityQue = "My pet's name";
            trader.Answer = "tom";
            var mock = new Mock<ITraderRepository>();
            mock.Setup(p => p.UpdateTraderPassword(trader)).ReturnsAsync(true);
            traderServices = new TraderServices(mock.Object);
            var result = await traderServices.UpdateTraderPassword(trader);
            Assert.AreEqual(true, result);
        }
    }
}
