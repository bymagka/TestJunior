using Moq;
using Assert = Xunit.Assert;
using DAL.Repositories.Interfaces;
using BLL.Domain.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using BLL.Services;
using DAL.Entities;
using System.Collections.Generic;

namespace Services.Tests
{
    [TestClass]
    public class SalesPointServiceTest
    {
        private Mock<ISalesPointsRepo> salesPointRepoMock;

        private Mock<IProductsRepo> productsRepoMock;

        private Mock<ILogger<SalesPointService>> loggerMock;

        private ISalesPointService salesPointService;

        [TestInitialize]
        public void TestInitialize()
        {

            var testProduct1 = new Product { Id = 0, Name = "Карандаш", Price = 100.99m };
            var testProduct2 = new Product { Id = 1, Name = "Ручка", Price = 200.99m };
            var testProduct3 = new Product { Id = 2, Name = "Тетрадь", Price = 300.99m };


            var testSalesPoint1 = new SalesPoint
            {
                Id = 0,
                Name = "Основная точка",
                ProvidedProducts = new List<ProvidedProduct> {
                new ProvidedProduct { Product = testProduct1, Quantity = 3 },
                new ProvidedProduct { Product = testProduct2, Quantity = 10 },
            }
            };
            var testSalesPoint2 = new SalesPoint { Id = 1, Name = "Запасная точка", ProvidedProducts = new List<ProvidedProduct> { new ProvidedProduct { Product = testProduct3, Quantity = 5 } } };


            var salesPointsList = new List<SalesPoint>() { testSalesPoint1, testSalesPoint2 };


            salesPointRepoMock = new Mock<ISalesPointsRepo>();
            salesPointRepoMock.Setup(x => x.GetAll()).Returns(salesPointsList);

            productsRepoMock = new Mock<IProductsRepo>();

            loggerMock = new Mock<ILogger<SalesPointService>>();

            salesPointService = new SalesPointService(salesPointRepoMock.Object, productsRepoMock.Object, loggerMock.Object);
        }


        [TestMethod]
        public void BuyerService_GetAll_CorrectCount()
        {
            var salesPoints = salesPointService.GetAll();

            Assert.Equal(2, salesPoints.Count);
        }
    }
}
