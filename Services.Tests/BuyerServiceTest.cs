using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using Assert = Xunit.Assert;
using DAL.Entities;
using Moq;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using BLL.Domain.BusinessObjects;

namespace Services.Tests
{
    [TestClass]
    public class BuyerServiceTest
    {
        private Mock<IBuyersRepo> buyersRepoMock;

        private Mock<ILogger<BuyerService>> loggerMock;

        private IBuyerService buyerService;

        [TestInitialize]
        public void TestInitialize()
        {

            var buyers = new Buyer[] {

            new Buyer {Id = 1, Name = "ООО Рога и копыта", SalesIds = new List<SaleId> { new SaleId { Value = 1 }, new SaleId { Value = 2 } } },
            new Buyer {Id = 2, Name = "ООО Ромашка", SalesIds = new List<SaleId> { new SaleId { Value = 3 }, new SaleId { Value = 4 } } },

            };

            buyersRepoMock = new Mock<IBuyersRepo>();
            loggerMock = new Mock<ILogger<BuyerService>>();

            buyersRepoMock.Setup(x => x.GetAll()).Returns(buyers);

            

            buyersRepoMock.Setup(x => x.GetOne(1)).Returns(new Buyer {Id = 1, Name = "ООО Рога и копыта", SalesIds = new List<SaleId> { new SaleId { Value = 1 }, new SaleId { Value = 2 } }});

            buyerService = new BuyerService(buyersRepoMock.Object, loggerMock.Object); 
        }

        [TestMethod]
        public void BuyerService_GetAll_CorrectCount()
        {
            var buyers = buyerService.GetAll();

            Assert.Equal(2, buyers.Count);

            Assert.IsType<List<BO_Buyer>>(buyers);
        }

        [TestMethod]
        public void BuyerService_GetOne_CorrectType()
        {
            var input_id = 1;

            var buyer = buyerService.Get(input_id);

            Assert.IsType<BO_Buyer>(buyer);
        }

        [TestMethod]
        public void BuyerService_GetOne_CorrectTransform()
        {
            var input_id = 1;

            var buyer = buyerService.Get(input_id);

            Assert.Equal(input_id.ToString(), buyer.Id.ToString());

            Assert.IsType<List<BO_SaleId>>(buyer.SalesIds);
        }
    }
}
