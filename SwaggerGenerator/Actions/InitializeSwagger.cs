using PowerArgs;
using SwaggerGenerator.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerGenerator.Actions
{
    [ArgActions]
    public class InitializeSwaggerArgs
    {
        [ArgRequired]
        [StickyArg]
        public string SwaggerFilePath { get; set; }

        [ArgRequired]
        public string HostName { get; set; }

        [ArgRequired]
        public string[] Schemes { get; set; }

        [ArgRequired]
        public string BasePath { get; set; }

        public string Description { get; set; }

        [ArgRequired]
        public string Title { get; set; }

        [ArgRequired]
        public string Version { get; set; }

        [ArgActionMethod]
        public static void InitializeSwagger(InitializeSwaggerArgs args)
        {
            var swagger = new SwaggerDefinition
            {
                Host = args.HostName,
                Schemes = args.Schemes,
                BasePath = args.BasePath,
                Info = new SwaggerInfo
                {
                    Description = args.Description,
                    Title = args.Title,
                    Version = args.Version
                },
                Consumes = new string[] { "application/json" },
                Produces = new string[] { "application/json" },
            };

            swagger.SaveToDisk(args.SwaggerFilePath);
        }
    }
}
