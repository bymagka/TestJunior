using Microsoft.Extensions.Logging;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{ 
    /// <summary>
    /// Репозиторий точек продаж
    /// </summary>
    public class SalesPointRepo : BaseRepo<SalesPoint>, ISalesPointsRepo
    {
        private readonly ILogger<SalesPointRepo> _logger;

        public SalesPointRepo(MyContext dbContext, ILogger<SalesPointRepo> logger) : base(dbContext)
        {
            this._logger = logger;
        }
    }
}
