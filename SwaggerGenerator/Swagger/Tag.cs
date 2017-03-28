using Newtonsoft.Json;

namespace SwaggerGenerator.Swagger
{
    public class Tag
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }
    }
}
