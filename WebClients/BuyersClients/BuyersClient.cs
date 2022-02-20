using System.Collections.Generic;
using BLL.Services;
using BLL.Domain.BusinessObjects;
using System.Net.Http;
using System.Net.Http.Json;

namespace WebClients
{
    public class BuyersClient : BaseClient, IBuyerService
    {

        public BuyersClient(HttpClient Client) : base(Client,WebAddresses.Buyers)
        {

        }

        public bool Add(BO_Buyer businessObject)
        {
            var response = Post(Adress, businessObject);
            var newBuyer = response.Content.ReadFromJsonAsync<BO_Buyer>().Result;

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
            var response = Delete<BO_Buyer>($"{Adress}/{id}");
            return response.IsSuccessStatusCode;
        }

        public BO_Buyer Get(int id)
        {
            var buyer = Get<BO_Buyer>($"{Adress}/{id}");
            return buyer;
        }

        public ICollection<BO_Buyer> GetAll()
        {
            var buyers = Get<ICollection<BO_Buyer>>($"{Adress}");
            return buyers;
        }

        public bool Update(BO_Buyer businessObject)
        {
            var result = Put($"{Adress}", businessObject);

            return result.IsSuccessStatusCode;
        }
    }
}
