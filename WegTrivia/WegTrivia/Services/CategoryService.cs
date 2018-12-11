using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WegTrivia.Models;
using WegTrivia.Models.Responses;
using WegTrivia.Helpers;

namespace WegTrivia.Services
{
    public class CategoryService : WegmansServiceBase
    {
        public CategoryService(HttpClient client)
        {
            Client = client;
            route = "products/categories";
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            fullServicePath = $"/{route}?api-version={apiVersion}&Subscription-Key={subscriptionKey}";
            var response = await CallService<CategoriesResponse>(route);
            return response.Categories;
        }

        public async Task<Category> GetRandomCategoryAsync()
        {
            //TODO: Fix this, it was bombing on long unmarshall
            //var cats = await GetCategoriesAsync();
            //return cats.GetRandomItem();
            return null;
        }
    }
}