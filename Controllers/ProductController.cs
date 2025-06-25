using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productManager.Data;
using productManager.Models;
using productManager.Models.Entities;

namespace productManager.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add() { 
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel viewModel) {
            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return View(viewModel);

        }

    }
}
