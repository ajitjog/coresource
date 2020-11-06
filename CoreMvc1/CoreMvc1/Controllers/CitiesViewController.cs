using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreMvc1.Controllers
{
    public class CitiesViewController : Controller
    {

        private IConfiguration _config;
        public CitiesViewController(IConfiguration c)
        {
            this._config = c;
        }


        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult Index2()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync(_config.GetSection("externalservices")["apiurl"]);

            var msg =  stringTask.Result;
            this.ViewData["msg"] = msg;
            return View("Index2",msg);
        }

        public IActionResult Index3()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync(_config.GetSection("externalservices")["apiurl2"]);

            var msg = stringTask.Result;
            this.ViewData["msg"] = msg;
            return View("Index2", msg);
        }


    }
}