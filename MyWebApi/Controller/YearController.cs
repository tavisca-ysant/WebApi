using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyWebApi.Controller
{
    public class Year
    {
        public int year { get; set; }
        public bool IsLeap { get; set; }
    }
    public class YearController : ApiController
    {
        Year[] years = new Year[]
            {
            new Year {year = 2012, IsLeap = true },
            new Year { year = 2014, IsLeap = false}
            };


        public IEnumerable<Year> Get()
        {
            return years.ToList();
        }
        
        public Year Get(int year)
        {
            try
            {
                return years[year];
            }
            catch (Exception)
            {
                return new Year();
            }
        }
    }
}
