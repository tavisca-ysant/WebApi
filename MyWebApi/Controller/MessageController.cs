using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyWebApi.Controller
{
    public class MessageController : ApiController
    {
        public string Get(string token)
        {
            if (token == "hello")
                return "hi";
            else if (token == "hi")
                return "hello";
            return "Invalid Input";
        }
    }
}
