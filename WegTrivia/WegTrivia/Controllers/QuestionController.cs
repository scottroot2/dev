using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WegTrivia.Models.Responses;
using WegTrivia.Services;

namespace WegTrivia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly SearchService _searchService;
        private readonly PriceService _priceService;

        public QuestionController(SearchService searchService, PriceService priceService)
        {
            _searchService = searchService;
            _priceService = priceService;
        }

        // GET: api/Question
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public ContentResult Post([FromBody] dynamic dialogFlowRequest)
        {
            //TODO: Make async
            var productCategory = dialogFlowRequest.queryResult.parameters.ProductCategory[0].Value as String; 
            var product = _searchService.GetRandomProductFromQueryAsync(productCategory).Result;
            string fulfillmentTextOutput = $"Great! I found {product.Name}. ";
            string plainText = fulfillmentTextOutput;

            if (!string.IsNullOrEmpty(product.Sku))
            {
                try
                {
                    var price = _priceService.GetPrice(product.Sku.ToString()).Result;
                    fulfillmentTextOutput += $"It looks like it is on sale too for <say-as interpret-as=\"unit\">${price}</say-as>!";
                    plainText += $"It looks like it is on sale too for ${price}!";
                }
                catch (Exception)
                {
                    //TODO: Handle this..or eat it
                }

            }

            SsmlResponse response = new SsmlResponse()
            {
                FulfillmentText = plainText,
                Payload = new Models.Responses.Payload
                {
                    Google = new Models.Responses.Google
                    {
                        ExpectUserResponse = true,
                        RichResponse = new Models.Responses.RichResponse
                        {
                            Items = new List<Models.Responses.Item>()
                            {
                                new Models.Responses.Item
                                {
                                    SimpleResponse = new Models.Responses.SimpleResponse
                                    {
                                        DisplayText="Turn on SSML",
                                        Ssml = $"<speak>{fulfillmentTextOutput}</speak>"

                                    }
                                }
                            }
                        }
                    }
                }
            };
            return Content(JsonConvert.SerializeObject(response), "application/json");

            //var r = new StreamReader("Models\\hardcoded.json");
            //var myJson = r.ReadToEnd();
            //return Content(myJson);

            //return Content(JsonConvert.SerializeObject(new
            //{
            //    fulfillmentText = fulfillmentTextOutput,
            //    ssml = "<say-as interpret-as=\"unit\">$2043.75</say-as>"
            //}
            //), "application/json");

        }


    }
}

