using BLL.Domain.BusinessObjects;


namespace SalesAPI.Services
{
    public interface ICreateSaleService
    {
        public bool Add(BO_Sale sale);
    }
}
