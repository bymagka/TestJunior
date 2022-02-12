using Microsoft.Extensions.Logging;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class SalesRepo : BaseRepo<Sale>, ISalesRepo
    {
        private readonly ILogger<SalesRepo> _logger;

        public SalesRepo(MyContext dbContext, ILogger<SalesRepo> logger) : base(dbContext)
        {
            this._logger = logger;
        }
    }
}
