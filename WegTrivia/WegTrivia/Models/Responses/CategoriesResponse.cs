using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WegTrivia.Models.Responses
{
    public partial class CategoriesResponse
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("_links")]
        public List<Link> Links { get; set; }
    }



    public partial class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("rel")]
        public Rel Rel { get; set; }

        [JsonProperty("type")]
        public LinkType Type { get; set; }
    }

    public enum Rel { Availabilities, Locations, Next, Prices, Self, Products };

    public enum LinkType { Get };

    public enum CategoryType { Department };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                RelConverter.Singleton,
                LinkTypeConverter.Singleton,
                CategoryTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class RelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Rel) || t == typeof(Rel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "products":
                    return Rel.Products;
                case "self":
                    return Rel.Self;
            }
            throw new Exception("Cannot unmarshal type Rel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Rel)untypedValue;
            switch (value)
            {
                case Rel.Products:
                    serializer.Serialize(writer, "products");
                    return;
                case Rel.Self:
                    serializer.Serialize(writer, "self");
                    return;
            }
            throw new Exception("Cannot marshal type Rel");
        }

        public static readonly RelConverter Singleton = new RelConverter();
    }

    internal class LinkTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LinkType) || t == typeof(LinkType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "GET")
            {
                return LinkType.Get;
            }
            throw new Exception("Cannot unmarshal type LinkType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LinkType)untypedValue;
            if (value == LinkType.Get)
            {
                serializer.Serialize(writer, "GET");
                return;
            }
            throw new Exception("Cannot marshal type LinkType");
        }

        public static readonly LinkTypeConverter Singleton = new LinkTypeConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class CategoryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CategoryType) || t == typeof(CategoryType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Department")
            {
                return CategoryType.Department;
            }
            throw new Exception("Cannot unmarshal type CategoryType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CategoryType)untypedValue;
            if (value == CategoryType.Department)
            {
                serializer.Serialize(writer, "Department");
                return;
            }
            throw new Exception("Cannot marshal type CategoryType");
        }

        public static readonly CategoryTypeConverter Singleton = new CategoryTypeConverter();
    }
}
