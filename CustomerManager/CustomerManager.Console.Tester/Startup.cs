using CustomerManager.Data;
using CustomerManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Console.Tester
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // Application for testing the wrote code.
            var httpClient = new HttpClient();

            var asd = httpClient.GetAsync("http://localhost:56638/api/customers");

            var asdds = asd.Result;
        }
    }
}
