using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using DockerTestProject.Models;
using DockerTestProject.Middleware;

namespace DockerTestProject {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            ConfigureDatabase(services);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole(LogLevel.Debug);

            // ensure the database has been seeded
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DTPContext>().EnsureSeedData();
            }

            // load our custom middleware
            app.UseRequestId();

            app.UseFileServer();

            app.UseMvc();
        }

        private void ConfigureDatabase(IServiceCollection services) {
            // pull the database connection string from the environment
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");
            if (String.IsNullOrWhiteSpace(connectionString)) {
                // fallback to the local machine
                connectionString = "postgres://postgres@localhost/docker-test-project";
            }
            services.AddDbContext<DTPContext>(options =>
                options.UseNpgsql( StartupHelper.GetConnectionString(connectionString) )
            );
        }
    }
}
