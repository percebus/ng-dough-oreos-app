
namespace WebApp
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Connectors;
    using Connectors.Data;
    using EntityGraphQL.AspNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using WebApp.Options;

    public class Program
    {
        protected static JsonStringEnumConverter JsonStringEnumConverter = new();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.env.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services
                .AddOptions<ServiceOptions>()
                .BindConfiguration(ServiceOptions.Key);
            //.ValidateFluently() // TODO
            //.ValidateOnStart(); // TODO

            var provider = builder.Services.BuildServiceProvider();
            var optionsMonitor = provider.GetRequiredService<IOptionsMonitor<ServiceOptions>>();

            ServiceOptions config;
            config = provider.GetRequiredService<IOptionsMonitor<ServiceOptions>>().CurrentValue;

            builder.Services
                .AddOpenApi() // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
                .AddCors()
                .AddControllers()
                .AddJsonOptions(opts =>
                {
                    // Use enum field names instead of numbers
                    opts.JsonSerializerOptions.Converters.Add(JsonStringEnumConverter);

                    // EntityGraphQL internally builds types with fields
                    opts.JsonSerializerOptions.IncludeFields = true;

                    // The fields internally built already are named with fieldNamer (defaults to camelCase). This is
                    // for the properties on QueryResult (Data, Errors) to match what most tools etc expect (camelCase)
                    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            builder.Services.AddDbContext<FirstAppContext>(options => options.UseSqlServer(config.Database.ReadConnectionString));

            // EntityGraphQL
            builder.Services
                .AddGraphQLSchema<FirstAppContext>();

            // HotChocolate Nitro (Formerly "Banana Cake Pop")
            builder.Services
                .AddGraphQLServer();

            var app = builder.Build();
            CreateDbIfNotExists(app.Services);

            app
                // .UseAuthentication() // TODO
                // .UseAuthorization() // TODO
                .UseRouting()
                .UseHttpsRedirection()
                .UseCors(x => x // FIXME HACK CORS workaround for
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Swagger"));
            }

            // TODO?
            //app.UseEndpoints(endpoints =>
            //{
            //    // defaults to /graphql endpoint
            //    endpoints.MapGraphQL<FirstAppContext>(configureEndpoint: (endpoint) =>
            //    {
            //        endpoint.RequireAuthorization("authorized"); // TODO
            //
            //        // do other things with endpoint
            //    });
            //});

            app.MapControllers();
            app.MapGraphQL<FirstAppContext>(); // EntityGraphQL
            app.MapGraphQL(); // HotChocolate Nitro (Formerly "Banana Cake Pop")

            app.Run();
        }


        private static void CreateDbIfNotExists(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                try
                {
                    var context = scopedServices.GetRequiredService<FirstAppContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = scopedServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
