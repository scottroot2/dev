using Newtonsoft.Json;
using System.Collections.Generic;
using WegTrivia.Models.Responses;

namespace WegTrivia.Models
{
    public partial class Category
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public CategoryType Type { get; set; }

        [JsonProperty("_links")]
        public List<Link> Links { get; set; }
    }
}
