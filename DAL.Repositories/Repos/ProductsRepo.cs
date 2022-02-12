using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using DAL.Entities;

namespace DAL.Repositories
{
    /// <summary>
    /// Репозиторий товаров
    /// </summary>
    public class ProductsRepo : BaseRepo<Product>, IProductsRepo
    {
        private readonly ILogger<ProductsRepo> _logger;

        public ProductsRepo(MyContext dbContext, ILogger<ProductsRepo> logger) : base(dbContext)
        {
            this._logger = logger;
        }
    }
}
