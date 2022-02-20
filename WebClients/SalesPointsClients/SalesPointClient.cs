using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using BLL.Domain.BusinessObjects;
using BLL.Services;

namespace WebClients
{
    public class SalesPointClient : BaseClient,ISalesPointService
    {

        public SalesPointClient(HttpClient Client) : base(Client, WebAddresses.SalesPoints)
        {

        }

        public bool Add(BO_SalesPoint businessObject)
        {
            var response = Post(Adress, businessObject);
            var newBuyer = response.Content.ReadFromJsonAsync<BO_SalesPoint>().Result;

            if (newBuyer.Id > 0 && response.IsSuccessStatusCode)
            {
                businessObject = newBuyer;
                return true;
            }
            else
                return false;

        }

        public bool Delete(int id)
        {
            var response = Delete<BO_SalesPoint>($"{Adress}/{id}");
            return response.IsSuccessStatusCode;
        }

        public BO_SalesPoint Get(int id)
        {
            var buyer = Get<BO_SalesPoint>($"{Adress}/{id}");
            return buyer;
        }

        public ICollection<BO_SalesPoint> GetAll()
        {
            var buyers = Get<ICollection<BO_SalesPoint>>($"{Adress}");
            return buyers;
        }

        public bool Update(BO_SalesPoint businessObject)
        {
            var result = Post($"{Adress}/update", businessObject);

            return result.IsSuccessStatusCode;
        }
    }
}
