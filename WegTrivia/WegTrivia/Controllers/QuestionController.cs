using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WegTrivia.Models;
using WegTrivia.Models.Responses;
using WegTrivia.Services;

namespace WegTrivia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly SearchService _searchService;

        public QuestionController(SearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: api/Question
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/Question/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Question
        [HttpPost]
        public async Task<ActionResult<QuestionResponse>> PostAsync([FromBody] string queryText)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _searchService.GetRandomProductFromQueryAsync(queryText);
            if (product == null)
                return NotFound("No product found.");

            QuestionResponse qr = new QuestionResponse
            {
                ProductName = product.Name
            };
            return Ok(qr);
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
