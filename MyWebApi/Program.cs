using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi
{
    class Program
    {
        const string baseAddress = "http://localhost:9000/";
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(baseAddress))
            {
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/year").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
                Console.WriteLine("Server started at:" + baseAddress);
                Console.ReadLine();
            }
        }
    }
}
