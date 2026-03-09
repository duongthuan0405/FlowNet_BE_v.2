using dotenv.net;

namespace WebAPI.ClassExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        private static string[] dotEnvDevelopmentFiles = ["Environment/.env.development"];
        public static WebApplicationBuilder LoadEnvironmentVariables(this WebApplicationBuilder builder)
        {
            string[] files = [];
            if (builder.Environment.IsDevelopment())
            {
                files = dotEnvDevelopmentFiles;

                var finalFiles = files.Select(file => Path.Combine(builder.Environment.ContentRootPath, file)).ToArray();

                DotEnv.Load(new DotEnvOptions(ignoreExceptions: false, envFilePaths: finalFiles, overwriteExistingVars: true));
            }


            builder.Configuration.AddEnvironmentVariables();

            return builder;
        }
    }
}
