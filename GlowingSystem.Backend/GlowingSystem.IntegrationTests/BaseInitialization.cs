using AutoFixture;
using GlowingSystem.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Respawn;
using Respawn.Graph;

namespace GlowingSystem.IntegrationTests
{
    [Collection("BaseCollection")]
    public class BaseInitialization : IAsyncLifetime
    {
        private string _connectionString = "Server=host.docker.internal,1433; User Id=ASU; Password=123AsdCvb; Database=GlowingSystemTestDb; TrustServerCertificate=True;";
        protected WebApplicationFactory<Program> _app;
        protected readonly IServiceScope _scope;
        protected readonly HttpClient _client;
        protected readonly GlowingSystemDbContext _dbContext;
        protected readonly Fixture _fixture;
        private Respawner _respawner = null!;

        public BaseInitialization(WebApplicationFactory<Program> app)
        {
            _app = app.WithWebHostBuilder(webHostBuilder =>
            {
                webHostBuilder.UseEnvironment("IntegrationTests");
            });
            _scope = _app.Services.CreateScope();
            _client = _app.CreateClient();
            _dbContext = _scope.ServiceProvider.GetRequiredService<GlowingSystemDbContext>();
            _fixture = new Fixture();
        }

        public async Task DisposeAsync()
        {
            await _respawner.ResetAsync(_connectionString);
        }

        public async Task InitializeAsync()
        {
            await _dbContext.Database.MigrateAsync();
            _respawner = await Respawner
                .CreateAsync(_connectionString, new RespawnerOptions
                {
                    TablesToIgnore = new Table[]
                    {
                        "__EFMigrationsHistory"
                    }
                });
        }
    }
}
