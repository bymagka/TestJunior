using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using BLL.Domain.BusinessObjects;
using BLL.Services;

namespace WebClients
{
    public class SalesClient : BaseClient,ISaleService
    {
        public SalesClient(HttpClient Client) : base(Client, WebAddresses.Sales)
        {

        }

        public bool Add(BO_Sale sale)
        {
            var response = Post(Adress, sale);
            var newSale = response.Content.ReadFromJsonAsync<BO_Sale>().Result;

            if (newSale.Id > 0 && response.IsSuccessStatusCode)
            {
                sale.Id = newSale.Id;
                return true;
            }
            else
                return false;

        }

        public bool Delete(int id)
        {
            var response = Delete<BO_Sale>($"{Adress}/{id}");
            return response.IsSuccessStatusCode;
        }

        public BO_Sale Get(int id)
        {
            var buyer = Get<BO_Sale>($"{Adress}/{id}");
            return buyer;
        }

        public ICollection<BO_Sale> GetAll()
        {
            var buyers = Get<ICollection<BO_Sale>>($"{Adress}");
            return buyers;
        }

        public bool Update(BO_Sale businessObject)
        {
            var result = Put($"{Adress}", businessObject);

            return result.IsSuccessStatusCode;
        }
    }
}
