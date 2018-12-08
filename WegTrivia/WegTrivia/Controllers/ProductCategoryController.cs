using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WegTrivia.Models;
using WegTrivia.Services;

namespace WegTrivia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public ProductCategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //[HttpGet]
        //public async Task<ActionResult<List<Category>>> GetRandomProductCategoryAsync()
        //{
        //    //CategoryService catSvc = new CategoryService(new System.Net.Http.HttpClient());
        //    //Get all categories
        //    var categories = await _categoryService.GetCategoriesAsync(); 
        //    //Pick a Random one
        //    return Ok(categories);
        //}
        [HttpGet]
        public async Task<ActionResult<Category>> GetRandomProductCategoryAsync()
        {
            var category = await _categoryService.GetRandomCategoryAsync();
            if (category == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(category);
        }
    }
}