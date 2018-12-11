using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WegTrivia.Models;
using WegTrivia.Models.Responses;

namespace WegTrivia.Services
{
    public class PriceService : WegmansServiceBase
    {
        //https://api.wegmans.io/products/484208/prices/25?api-version=2018-10-18
        public PriceService(HttpClient httpClient)
        {
            Client = httpClient;
            route = "products";
        }

        public async Task<decimal> GetPrice(string sku)
        {
            string storeNumber = "25";
            fullServicePath = $"{route}/{sku}/prices/{storeNumber}?api-version={apiVersion}&Subscription-Key={subscriptionKey}";
            //call base to do the work
            var response = await CallService<PriceResponse>(route);
            return (decimal)response.Price;
        }
    }
}
