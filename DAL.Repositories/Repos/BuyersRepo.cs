using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories
{
    /// <summary>
    /// Репозиторий покупателей
    /// </summary>
    public class BuyersRepo : BaseRepo<Buyer>,IBuyersRepo
    {
        private readonly ILogger<BuyersRepo> _logger;

        public BuyersRepo(MyContext dbContext,ILogger<BuyersRepo> logger) : base(dbContext)
        {
            this._logger = logger;       
        }
    }
}
