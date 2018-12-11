namespace WegTrivia.Models.Responses
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PriceResponse
    {
        [JsonProperty("sku")]
        public long Sku { get; set; }

        [JsonProperty("store")]
        public long Store { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("promotion")]
        public object Promotion { get; set; }

        //[JsonProperty("_links")]
        //public List<Link> Links { get; set; }
    }

    public partial class Dates
    {
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }
}
