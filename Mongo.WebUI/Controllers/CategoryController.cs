using Microsoft.AspNetCore.Mvc;
using Mongo.WebUI.Context;
using Mongo.WebUI.DAL.Services;
using Mongo.WebUI.Entities;
using MongoDB.Bson;

namespace Mongo.WebUI.Controllers
{
    public class CategoryController : Controller
    {
      private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> repository)
        {
            _categoryRepository = repository;
        }

        public IActionResult Index()
        {
            var values = _categoryRepository.GetList();
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryRepository.Create(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(ObjectId id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(ObjectId id)
        {
            var category = _categoryRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
           _categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
    }
}
