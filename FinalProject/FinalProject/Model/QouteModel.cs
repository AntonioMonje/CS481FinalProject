    using System;
    using System.Net;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Newtonsoft.Json;

namespace FinalProject.Model
{
    public static class QouteItemModel
    {
        public partial class GettingStarted
        {
            [JsonProperty("contents")]
            public Contents Contents { get; set; }

            [JsonProperty("success")]
            public Success Success { get; set; }
        }

        public partial class Success
        {
            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public partial class Contents
        {
            [JsonProperty("quotes")]
            public Quote[] Quotes { get; set; }
        }

        public partial class Quote
        {
            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("length")]
            public string Length { get; set; }

            [JsonProperty("quote")]
            public string PurpleQuote { get; set; }

            [JsonProperty("tags")]
            public string[] Tags { get; set; }
        }

        public partial class GettingStarted
        {
            public static GettingStarted FromJson(string json) => JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }

       
            public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
        

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
}