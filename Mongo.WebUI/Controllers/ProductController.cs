using Microsoft.AspNetCore.Mvc;
using Mongo.WebUI.DAL.Services;
using Mongo.WebUI.Entities;
using MongoDB.Bson;

namespace Mongo.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetList();
            return View(products);
        }

        public IActionResult Delete(ObjectId id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productRepository.Create(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
