namespace WegTrivia.Models.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class SsmlResponse
    {
        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }
    }

    public partial class Payload
    {
        [JsonProperty("google")]
        public Google Google { get; set; }
    }

    public partial class Google
    {
        [JsonProperty("expectUserResponse")]
        public bool ExpectUserResponse { get; set; }

        [JsonProperty("richResponse")]
        public RichResponse RichResponse { get; set; }
    }

    public partial class RichResponse
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("simpleResponse")]
        public SimpleResponse SimpleResponse { get; set; }
    }

    public partial class SimpleResponse
    {
        [JsonProperty("ssml")]
        public string Ssml { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
    }
}
