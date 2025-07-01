using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult List()
        {
            var data = _context.StorePrdt
             .Include(sp => sp.Product)
                 .ThenInclude(p => p.Types)
             .Include(sp => sp.Store)
             .Select(sp => new StoreProductViewModel
             {
                 ProductName = sp.Product.Name,
                 Price = sp.Product.Price,
                 Gender = sp.Product.Types.Gender,
                 StoreName = sp.Store.StorName
             })
             .ToList();
            return View(data);
        }


        [HttpPost]
        public IActionResult Filter(Guid ProductId, Guid SelectStorID, string name, string price)
        {
            var product =  _context.Products.Find(ProductId);
            if (product is not null)
            {
                product.Name = name;
                product.Price = price;
                _context.SaveChanges();
            }

            var AddStore = _context.StorePrdt
                .FirstOrDefault(x => x.PrdtId == ProductId);
                if (AddStore == null) {
                    var storePrdt = new StorePrdt
                    {
                        PrdtId = ProductId,
                        StoreId = SelectStorID
                    };

                    _context.StorePrdt.Add(storePrdt);
                    _context.SaveChangesAsync();
                }
            return RedirectToAction("list");
        }



        [HttpGet]
        public IActionResult Filter() {
            var products = _context.Products
                .Include(p => p.Types)
                .Select(p => new ProductInfo
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Gender = p.Types.Gender
                })
                .ToList();

            var stores = _context.Store
               .Select(s => new SelectListItem
               {
                   Value = s.Id.ToString(),
                   Text = s.StorName
               })
               .ToList();

            var viewModel = new FormDataViewModel
            {
                Products = products,
                Stores = stores
            };
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Add() {
            var model = new AddProductViewModel
            {
                GenderList = _context.types
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Gender
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel viewModel) {
            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                TypeId = viewModel.TypeId
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Store()
        {

            var list = _context.Store
               .Select(s => new AddStoreViewModel
               {
                   StorName = s.StorName
               })
               .ToList();

            var model = new AddStoreViewModel
            {
                StoreList = list
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult GetStore() {
            var list = _context.Store
               .Select(s => new AddStoreViewModel
               {
                   StorName = s.StorName
               })
               .ToList();
            return Json(list);
        }


        [HttpPost]
        public IActionResult Store(AddStoreViewModel viewModel)
        {
            if (viewModel.StorName != null) {
                var store = new Store
                {
                    StorName = viewModel.StorName
                };

                _context.Store.Add(store);
                _context.SaveChanges();
            }

            var list = _context.Store
               .Select(s => new AddStoreViewModel
               {
                   StorName = s.StorName
               })
               .ToList();
            return Ok(list);
        }

    }
}
