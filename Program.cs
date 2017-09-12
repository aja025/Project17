using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project17.Data;

namespace Project17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            var artist = new Artist
            {
                Name = "Testing2"
            };

            Console.WriteLine(artist.Name);

        
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
