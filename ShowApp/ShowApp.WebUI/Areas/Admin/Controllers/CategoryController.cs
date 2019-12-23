using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using ShowApp.Entity;

namespace ShowApp.WebUI.Areas.Admin.Controllers
{
   // [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository Repository;
        public CategoryController(ICategoryRepository _repository)
        {
            Repository = _repository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {

            return View(Repository.GetAll());
        }
        [HttpGet]
        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(Category entity)
        {
            Repository.AddCategory(entity);
            return RedirectToAction("List");
        }
        public IActionResult Update(Category entity)
        {
            Repository.UpdateCategory(entity);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            Repository.DeleteCategory(id);
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            var category = Repository.GetById(id);
            return View(category);
        }

    }
}
