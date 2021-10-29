using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public class StudentAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("CrudApiUrl"));
            client.BaseAddress = new Uri("http://CrudApi");
            return client;
        }
    }
}
