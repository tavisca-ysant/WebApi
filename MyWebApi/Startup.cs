using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

[assembly: OwinStartup(typeof(MyWebApi.Startup))]

namespace MyWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration Config = new HttpConfiguration();
            //Config.EnableCors();
            Config.Routes.MapHttpRoute(
                name: "leapYearApi",
                routeTemplate: "api/{controller}/{year}",
                defaults: new { year = RouteParameter.Optional }
            );
            app.UseWebApi(Config);
            // app.Use;

            TakeRequest(app);
        }

        public void TakeRequest(IAppBuilder app)
        {
            app.Run(async context =>
            {
                var formData = await context.Request.GetBodyParameters();
                var data = int.Parse(formData["year"]);
                
                var IsLeap = ((data % 4 == 0 && data % 100 != 0) || data % 400 == 0);
                JObject responseJSON = JObject.Parse(@"{'IsLeap': '" + IsLeap + @"'}");
                byte[] buf = Encoding.UTF8.GetBytes(responseJSON.ToString());
                context.Response.ContentLength = buf.Length;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(buf);
            });
        }
    }
}
