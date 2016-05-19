
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                                .UseKestrel()
                                .UseStartup<Startup>()
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                .Build();
            host.Run();
        }
    }
}
