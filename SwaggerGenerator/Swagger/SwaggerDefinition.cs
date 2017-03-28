using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace SwaggerGenerator.Swagger
{
    public class SwaggerDefinition
    {
        [JsonProperty(PropertyName = "swagger")]
        public string SwaggerVersion
        {
            get { return "2.0"; }
        }

        [JsonProperty]
        public SwaggerInfo Info { get; set; }

        [JsonProperty]
        public string Host { get; set; }

        [JsonProperty]
        public string BasePath { get; set; }

        [JsonProperty]
        public string[] Schemes { get; set; }

        [JsonProperty]
        public string[] Consumes { get; set; }

        [JsonProperty]
        public string[] Produces { get; set; }

        [JsonProperty]
        public Dictionary<string, Path> Paths { get; set; }

        [JsonProperty]
        public Dictionary<string, Schema> Definitions { get; set; }

        [JsonProperty]
        public Dictionary<string, Parameter> Parameters { get; set; }

        [JsonProperty]
        public Dictionary<string, SecurityDefinition> SecurityDefinitions { get; set; }

        [JsonProperty]
        public Dictionary<string, string[]>[] Security { get; set; }

        [JsonProperty]
        public Tag[] Tags { get; set; }

        [JsonProperty]
        public ExternalDocumentation ExternalDocs { get; set; }

        [JsonIgnore]
        private static JsonSerializerSettings JsonSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
            }
        }

        public void SaveToDisk(string filePath)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented, SwaggerDefinition.JsonSettings);

            if (Directory.Exists(System.IO.Path.GetDirectoryName(filePath)) == false)
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));
            }

            File.WriteAllText(filePath, json);
        }

        public static SwaggerDefinition LoadFromDisk(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<SwaggerDefinition>(json, SwaggerDefinition.JsonSettings);
            }

            return null;
        }
    }
}
