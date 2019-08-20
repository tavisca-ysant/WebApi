using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyWebApi
{
    class Program
    {
        const string baseAddress = "http://localhost:9000/";
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(baseAddress))
            {
               Console.WriteLine("Server started at:" + baseAddress);
                HttpClient client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/year").Result;
               // Console.WriteLine(response);
             //   Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
