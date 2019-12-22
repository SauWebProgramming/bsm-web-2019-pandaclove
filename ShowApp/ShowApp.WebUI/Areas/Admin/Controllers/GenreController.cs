using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using ShowApp.Entity;
namespace ShowApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private IGenreRepository Repository;
        public GenreController(IGenreRepository _repository)
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
        public IActionResult Add(Genre entity)
        {
            Repository.AddGenre(entity);
            return RedirectToAction("List");
        }
        public IActionResult Update(Genre entity)
        {
            Repository.UpdateGenre(entity);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var genre = Repository.GetById(id);
            return View(genre);
        }
        public IActionResult Delete(int id)
        {
            Repository.DeleteGenre(id);
            return RedirectToAction("List");
        }
    }
}
