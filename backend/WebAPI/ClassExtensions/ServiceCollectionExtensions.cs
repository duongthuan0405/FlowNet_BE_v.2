using Application.UseCases.Authentication.SignUp;
using Infrastructure.ClassExtensions;
using Microsoft.OpenApi.Models;

namespace WebAPI.ClassExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            // Add Controllers
            services.AddControllers();

            AddSwagger(services);
            services.AddDI(configuration);
            AddUseCases(services);
            return services;
        }

        private static void AddUseCases(IServiceCollection services)
        {
            AddAllUseCase(services);
            AddUCInputValidators(services);
        }

        private static void AddUCInputValidators(IServiceCollection services)
        {
            services.AddSingleton<SignUpUCInputValidator>();
        }

        private static void AddAllUseCase(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FlowNet",
                    Description = "A simple example ASP.NET Core Web API",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Format: Bearer {your JWT token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
