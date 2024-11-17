using GlowingSystem.API.ActionFilters;
using GlowingSystem.Converters;
using GlowingSystem.Extensions;
using GlowingSystem.MappingProfiles;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;

namespace GlowingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .CreateLogger();

            builder.Services.AddSerilog();

            builder.Services.ConfigureCors();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddServices();
            builder.Services.AddRepositories();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddScoped<ValidationFilterAttribute>();

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(API.AssemblyReference).Assembly)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateJsonConverter());
                });

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DataAccessMappingProfile>();
                cfg.AddProfile<BusinessLogicMappingProfile>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            app.ConfigureExceptionHandler(logger);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("GlowingSystemCorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
