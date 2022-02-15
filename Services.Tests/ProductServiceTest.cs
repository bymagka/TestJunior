using BLL.Domain.BusinessObjects;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using Assert = Xunit.Assert;

namespace Services.Tests
{
    [TestClass]
    public class ProductServiceTest
    {

        private Mock<IProductsRepo> productsRepoMock;

        private Mock<ILogger<ProductService>> loggerMock;

        private IProductService productService;

        [TestInitialize]
        public void TestInitialize()
        {
            var products = new Product[]
            {
             new Product { Id = 1, Name = "Карандаш", Price = 100.99m },
             new Product { Id = 2, Name = "Ручка", Price = 200.99m },
             new Product { Id = 3, Name = "Тетрадь", Price = 300.99m },
            };

            productsRepoMock = new Mock<IProductsRepo>();
            productsRepoMock.Setup(x => x.GetAll()).Returns(products);
            productsRepoMock.Setup(x => x.GetOne(1)).Returns(new Product { Id = 1, Name = "Карандаш", Price = 100.99m });
       

            loggerMock = new Mock<ILogger<ProductService>>();

            productService = new ProductService(productsRepoMock.Object, loggerMock.Object);
        }

        [TestMethod]
        public void ProductService_GetAll_CorrectCount()
        {
            var products = productService.GetAll();

            Assert.Equal(3, products.Count);

            Assert.Equal(typeof(BO_Product[]), products.ToArray().GetType());
        }


        [TestMethod]
        public void ProductService_GetOne_CorrectType()
        {
            var product = productService.Get(1);

            Assert.Equal(typeof(BO_Product), product.GetType());
        }

        [TestMethod]
        public void ProductService_GetOne_CorrectItem()
        {
            var product = productService.Get(1);

            Assert.Equal(1, product.Id);

        }


    }

}
