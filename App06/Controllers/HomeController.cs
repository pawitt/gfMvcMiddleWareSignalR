using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App06.Models;
using App06.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace App06.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<MyHub> myHub;

        public HomeController(IHubContext<MyHub> myHub)
        {
            this.myHub = myHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            myHub.Clients.All.SendAsync("ReceiveMessage", "a", "page about reach");
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForceRefresh()
        {
            myHub.Clients.All.SendAsync("ForceRefresh");
            return new EmptyResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}