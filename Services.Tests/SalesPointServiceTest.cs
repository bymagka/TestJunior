using Moq;
using Assert = Xunit.Assert;
using DAL.Repositories.Interfaces;
using BLL.Domain.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using BLL.Services;

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

        }
    }
}
