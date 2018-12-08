using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WegTrivia.Services
{
    public class WegmansServiceBase
    {
        //TODO: Move to appsettings.json
        private string wegmansServiceHost = "https://api.wegmans.io"; //"https://api.wegmans.io/products/categories?api-version=2018-10-18&Subscription-Key={{Your-Subscription-Key}}";
        protected string apiVersion = "2018-10-18";
        protected string subscriptionKey = "42cdc1036d134202be5fddb7fa8ce690";
        protected string fullServicePath = "";
        protected string route = "";
        public HttpClient Client { get; set; }


        protected async Task<T> CallService<T>(string route)
        {
            try
            {
                var response = await Client.GetAsync($"{wegmansServiceHost}/{fullServicePath}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<T>();
                return result; //change this to a real value.
            }
            catch(Exception ex)
            {
                string bad = ex.ToString();
                return default(T);
            }
            
        }
    }
}
