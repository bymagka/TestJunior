using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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

        public override ICollection<Buyer> GetAll()
        {
            return _table
                .Include(b=>b.SalesIds)
                .ToList();
        }

        public override Buyer GetOne(int id)
        {
            return _table
                .Include(b => b.SalesIds)
                .FirstOrDefault(b=>b.Id.Equals(id));
        }
    }
}
