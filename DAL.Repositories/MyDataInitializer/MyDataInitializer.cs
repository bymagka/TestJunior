using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
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

            productsRepo.Add(TestData.products);
        }
    }
}
