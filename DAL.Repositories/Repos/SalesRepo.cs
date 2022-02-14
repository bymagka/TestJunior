using Microsoft.Extensions.Logging;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class SalesRepo : BaseRepo<Sale>, ISalesRepo
    {
        private readonly ILogger<SalesRepo> _logger;

        public SalesRepo(MyContext dbContext, ILogger<SalesRepo> logger) : base(dbContext)
        {
            this._logger = logger;
        }

        public override ICollection<Sale> GetAll()
        {
            return _table
                .Include(s => s.SalesData)
                .ThenInclude(sd => sd.Product)
                .Include(s=>s.SalesPoint)
                .Include(s=>s.Buyer)
                .ToList();
        }

        public override Sale GetOne(int id)
        {
            return _table
                .Include(s => s.SalesData)
                .ThenInclude(sd => sd.Product)
                .Include(s=> s.SalesPoint)
                .Include(s => s.Buyer)
                .FirstOrDefault(s => s.Id.Equals(id));
        }
    }
}
