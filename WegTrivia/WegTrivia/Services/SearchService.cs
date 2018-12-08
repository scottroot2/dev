using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WegTrivia.Models;
using WegTrivia.Models.Responses;
using WegTrivia.Models.Responses2;
using WegTrivia.Helpers;

namespace WegTrivia.Services
{
    public class SearchService : WegmansServiceBase
    {
        //https://api.wegmans.io/products/search?query=orange%20juice&api-version=2018-10-18&results=10&page=1
        public SearchService(HttpClient httpClient)
        {
            Client = httpClient;
            route = "products/search";
        }

        public async Task<Product> GetRandomProductFromQueryAsync(string queryText)
        {
            fullServicePath = $"{route}?query={queryText}&results=20&page=1&api-version={apiVersion}&Subscription-Key={subscriptionKey}";
            //call base to do the work
            var response = await CallService<ProductQueryResponse>(route);
            var aRandomItem = response.Products.GetRandomItem();
            return aRandomItem;
        }
    }
}
