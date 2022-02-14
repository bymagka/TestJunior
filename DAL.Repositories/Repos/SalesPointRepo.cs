using Microsoft.Extensions.Logging;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public override ICollection<SalesPoint> GetAll()
        {
            return _table
                .Include(sp=>sp.ProvidedProducts)
                .ThenInclude(pp=>pp.Product)
                .ToList();
        }

        public override SalesPoint GetOne(int id)
        {
            return _table.Include(sp=>sp.ProvidedProducts)
                .ThenInclude(pp=>pp.Product)
                .FirstOrDefault(sp=>sp.Id.Equals(id));
        }
    }
}
