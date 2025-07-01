using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productManager.Data;
using productManager.Models;

namespace productManager.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GeteUser()
        {
            var users = _context.User.ToList();
            return Json(users);
        }

        [HttpPost]
        public IActionResult SubmitUser(string Name, int Phone, string Email)
        {
            var userdata = new productManager.Models.Entities.User
            {
                Name = Name,
                Phone = Phone,
                Email = Email
            };

            _context.User.Add(userdata);
            _context.SaveChanges();
            return Json(userdata);
        }


        [HttpGet]
        public IActionResult BuyPrdt() {
            return View();
        }

        [HttpGet]
        public IActionResult BuyPrdtInfo() {
            var products = _context.Products.ToList();
            return Json(products);
        }
    }
}
