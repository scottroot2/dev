using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WegTrivia.Models.Requests
{
    public partial class DialogFlowRequest
    {
        [JsonProperty("responseId")]
        public string ResponseId { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("queryResult")]
        public QueryResult QueryResult { get; set; }

        [JsonProperty("originalDetectIntentRequest")]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
    }

    public partial class OriginalDetectIntentRequest
    {
    }

    public partial class QueryResult
    {
        [JsonProperty("queryText")]
        public string QueryText { get; set; }

        //[JsonProperty("parameters")]
        //public Parameters Parameters { get; set; }
        [JsonProperty("parameters")]
        public QueryResultParameters Parameters { get; set; }

        [JsonProperty("allRequiredParamsPresent")]
        public bool AllRequiredParamsPresent { get; set; }

        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages")]
        public List<FulfillmentMessage> FulfillmentMessages { get; set; }

        [JsonProperty("outputContexts")]
        public List<OutputContext> OutputContexts { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("intentDetectionConfidence")]
        public long IntentDetectionConfidence { get; set; }

        [JsonProperty("diagnosticInfo")]
        public OriginalDetectIntentRequest DiagnosticInfo { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }

    public partial class QueryResultParameters
    {
        [JsonProperty("ProductCategory")]
        public List<string> ProductCategory { get; set; }
    }

    public partial class FulfillmentMessage
    {
        [JsonProperty("text")]
        public Text Text { get; set; }
    }

    public partial class Text
    {
        [JsonProperty("text")]
        public List<string> TextText { get; set; }
    }

    public partial class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public partial class OutputContext
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lifespanCount")]
        public long LifespanCount { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    public partial class Parameters
    {
        //[JsonProperty("any")]
        //public string StudentNumber { get; set; }
        [JsonProperty("ProductCategory")]
        public string ProductCategory { get; set; }
    }
    public partial class DialogFlowRequest
    {
        public static DialogFlowRequest FromJson(string json) => JsonConvert.DeserializeObject<DialogFlowRequest>(json, WegTrivia.Models.Responses.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DialogFlowRequest self) => JsonConvert.SerializeObject(self, WegTrivia.Models.Responses.Converter.Settings);
    }

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}
}
