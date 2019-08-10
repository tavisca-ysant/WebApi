using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

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
        }
    }
}
