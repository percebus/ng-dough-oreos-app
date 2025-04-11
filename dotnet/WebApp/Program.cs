
namespace WebApp
{
    using Connectors;
    using Connectors.Data;
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
                .AddDbContext<FirstAppContext>(options => options.UseSqlServer(config.Database.ReadConnectionString));

            builder.Services.AddCors();

            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            CreateDbIfNotExists(app.Services);

            // FIXME HACK CORS workaround for
            app.UseCors(x => x
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

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
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
