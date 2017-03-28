﻿using Newtonsoft.Json;

namespace SwaggerGenerator.Swagger
{
    public class Contact
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public string Email { get; set; }
    }
}
