using indigo.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace indigo.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController:Controller
    {
        readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
           
        }
    }
}
