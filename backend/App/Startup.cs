using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using DockerTestProject.Middleware;

namespace DockerTestProject {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            // pull the database connection string from the environment
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");
            if (String.IsNullOrWhiteSpace(connectionString)) {
                // fallback to the local machine
                connectionString = "postgres://postgres@localhost/docker-test-project";
            }
            services.AddDbContext<DTPContext>(options =>
                options.UseNpgsql( StartupHelper.GetConnectionString(connectionString) )
            );
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole(LogLevel.Debug);

            // load our custom middleware
            app.UseRequestId();

            app.UseFileServer();

            app.UseMvc();
        }
    }
}
