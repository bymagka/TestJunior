using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.MyDataInitializer
{
    public class MyDataInitializer
    {
        private readonly IProductsRepo productsRepo;
        private readonly IBuyersRepo buyerRepo;
        private readonly ISalesPointsRepo salesPointsRepo;
        private readonly ISalesRepo salesRepo;
        private readonly ILogger<MyDataInitializer> logger;

        public MyDataInitializer(IProductsRepo productsRepo,IBuyersRepo buyerRepo,ISalesPointsRepo salesPointsRepo,ISalesRepo salesRepo, ILogger<MyDataInitializer> logger)
        {
            this.productsRepo = productsRepo;
            this.buyerRepo = buyerRepo;
            this.salesPointsRepo = salesPointsRepo;
            this.salesRepo = salesRepo;
            this.logger = logger;
        }

        public void Initialize()
        {
            logger.LogInformation("Начало инициализации бд");

            logger.LogInformation("Инициализация товаров");
            var testProduct1 = new Product { Id = 0, Name = "Карандаш", Price = 100.99m };
            var testProduct2 = new Product { Id = 0, Name = "Ручка", Price = 200.99m };
            var testProduct3 = new Product { Id = 0, Name = "Тетрадь", Price = 300.99m };

            productsRepo.Add(new List<Product> {testProduct1,testProduct2,testProduct3 });
            logger.LogInformation("Инициализация товаров завершена");


            logger.LogInformation("Инициализация точек продаж");
            var testSalesPoint1 = new SalesPoint { Id = 0, Name = "Основная точка", ProvidedProducts = new List<ProvidedProduct> { 
                new ProvidedProduct { Product = testProduct1, Quantity = 3 },
                new ProvidedProduct { Product = testProduct2, Quantity = 10 },
            } };
            var testSalesPoint2 = new SalesPoint { Id = 0, Name = "Запасная точка", ProvidedProducts = new List<ProvidedProduct> { new ProvidedProduct { Product = testProduct3, Quantity = 5 } } };

            salesPointsRepo.Add(new List<SalesPoint> {testSalesPoint1,testSalesPoint2 });
            logger.LogInformation("Инициализация точек продаж завершена");

            logger.LogInformation("Инициализация покупателей");
            var testBuyer1 = new Buyer {Name = "ООО Рога и копыта",SalesIds = new List<SaleId> { new SaleId{Value = 1}, new SaleId {Value = 2 } } };
            var testBuyer2 = new Buyer { Name = "ООО Ромашка", SalesIds = new List<SaleId> { new SaleId { Value = 3 }, new SaleId { Value = 4 } } };
            buyerRepo.Add(new List<Buyer> { testBuyer1, testBuyer2 });
            logger.LogInformation("Инициализация покупателей завершена");


        }
    }
}
