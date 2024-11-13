using GlowingSystem.Converters;
using GlowingSystem.Extensions;
using GlowingSystem.MappingProfiles;
using System.Text.Json.Serialization;

namespace GlowingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureCors();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddServices();
            builder.Services.AddRepositories();

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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
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
