using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using ShowApp.WebUI.ViewModels;
namespace ShowApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IGenreRepository GenreRepository;
        private ICategoryRepository CategoryRepository;
        private IShowRepository ShowRepository;
        public HomeController(IGenreRepository genreRepository, ICategoryRepository categoryRepository, IShowRepository showRepository)
        {
            GenreRepository = genreRepository;
            CategoryRepository = categoryRepository;
            ShowRepository = showRepository;
        }
        public IActionResult Index()
        {
            var viewModel = new ShowGenreCategoryViewModel();
            viewModel.Categories = CategoryRepository.GetAll().ToList();
            viewModel.Genres = GenreRepository.GetAll().ToList();
            viewModel.Shows = ShowRepository.GetAll().ToList();
            return View(viewModel);
        }
    }
}
