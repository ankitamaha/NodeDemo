
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.IO;

namespace DockerTestProject {
    public class Program {
        public static void Main(string[] args) {
            var host = new WebHostBuilder()
                                .UseKestrel()
                                .UseStartup<Startup>()
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                .UseUrls("http://0.0.0.0:5000")
                                .Build();
            host.Run();
        }
    }
}
