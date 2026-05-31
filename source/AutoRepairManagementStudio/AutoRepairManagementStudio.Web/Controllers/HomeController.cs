using AutoRepairManagementStudio.DataAccessLayer.Database;
using AutoRepairManagementStudio.DataAccessLayer.Database.Entities;
using AutoRepairManagementStudio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoRepairManagementStudio.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(AutoRepairContext context)
        {
            //List<User> users = context.Users.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
