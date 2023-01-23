using indigo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace indigo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}