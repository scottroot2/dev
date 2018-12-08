namespace WegTrivia.Models.Responses2
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProductQueryResponse
    {
        [JsonProperty("results")]
        public List<Product> Products { get; set; }
        public long Pages { get; set; }
        public List<Link> Links { get; set; }
    }

    public partial class Link
    {
        public string Href { get; set; }
        public Rel Rel { get; set; }
        public TypeEnum Type { get; set; }
    }

    public partial class Result
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }
    }

    public enum Rel { Availabilities, Locations, Next, Prices, Self };

    public enum TypeEnum { Get };
}
