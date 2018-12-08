using Newtonsoft.Json;
using System.Collections.Generic;
using WegTrivia.Models.Responses;

namespace WegTrivia.Models
{
    public partial class Product
    {
        [JsonProperty("sku")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_links")]
        public List<Link> Links { get; set; }
    }
}
