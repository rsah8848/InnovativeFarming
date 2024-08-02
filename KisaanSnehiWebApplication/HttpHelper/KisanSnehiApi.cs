using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KisaanSnehiWebApplication.HttpHelper
{
    public class KisanSnehiApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61806");
            return client;
        }
    }
}
