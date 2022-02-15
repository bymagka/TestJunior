

using BLL.Domain.BusinessObjects;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyersRepo _buyersRepo;
        private readonly ILogger<BuyerService> _logger;

        public BuyerService(IBuyersRepo buyersRepo,  ILogger<BuyerService> logger)
        {
            this._buyersRepo = buyersRepo;
            this._logger = logger;
        }

        public bool Add(BO_Buyer businessObject)
        {
            var newBuyer = new Buyer
            {
                Name = businessObject.Name,
                SalesIds = businessObject.SalesIds.Select(si => new SaleId { Value = si.Value }).ToList()
            };

            var result = _buyersRepo.Add(newBuyer);

            if (result) businessObject.Id = newBuyer.Id;

            return result;
        }

        public bool Delete(int id)
        {
            var deletedBuyer = _buyersRepo.GetOne(id);

            if (deletedBuyer is null)
                return false;

            return _buyersRepo.Delete(deletedBuyer);
        }

        public BO_Buyer Get(int id)
        {
            var result = _buyersRepo.GetOne(id);

            if (result is null) return null;
            else return result.To_BO();
        }

        public ICollection<BO_Buyer> GetAll()
        {
            return _buyersRepo.GetAll().To_BO();
        }

        public bool Update(BO_Buyer businessObject)
        {
            var updatedBuyer = _buyersRepo.GetOne(businessObject.Id);

            if (updatedBuyer is null)
                return false;

            updatedBuyer.Name = businessObject.Name;
            updatedBuyer.SalesIds = businessObject.SalesIds.Select(si => new SaleId
            {
                Value = si.Value
            }).ToList();

            return _buyersRepo.Update(updatedBuyer);
        }
    }
}
