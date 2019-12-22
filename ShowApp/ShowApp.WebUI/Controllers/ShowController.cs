using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using ShowApp.WebUI.Areas.Admin.ViewModels;

namespace ShowApp.WebUI.Controllers
{
    public class ShowController : Controller
    {
        private IShowRepository ShowRepository;
        private ICategoryRepository CategoryRepository;
        private IGenreRepository GenreRepository;
        public ShowController(IShowRepository showRepository,
                              IGenreRepository genreRepository,
                              ICategoryRepository categoryRepository)
        {
            ShowRepository = showRepository;
            GenreRepository = genreRepository;
            CategoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var show = ShowRepository.GetById(id);
            ViewData["Category"] = CategoryRepository.GetById(show.CategoryId).Name;
            ViewData["Genre"] = GenreRepository.GetById(show.GenreId).Name;
            return View(show);
        }
    }
}