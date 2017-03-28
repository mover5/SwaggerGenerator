using Newtonsoft.Json;

namespace SwaggerGenerator.Swagger
{
    public class License
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Url { get; set; }
    }
}
