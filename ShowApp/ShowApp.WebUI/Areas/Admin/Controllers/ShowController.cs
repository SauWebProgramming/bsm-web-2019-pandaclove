using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShowApp.Data.Abstract;
using ShowApp.Entity;
using ShowApp.WebUI.Areas.Admin.ViewModels;
namespace ShowApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ShowController : Controller
    {


        private IShowRepository ShowRepository;
        private IGenreRepository GenreRepository;
        private ICategoryRepository CategoryRepository;

        public ShowController(IShowRepository showRepository, IGenreRepository genreRepository, ICategoryRepository categoryRepository)
        {
            ShowRepository = showRepository;
            GenreRepository = genreRepository;
            CategoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List(string? orderBy, int? value)
        {
            var viewModel = new ShowGenreCategoryViewModel();
            viewModel.Categories = CategoryRepository.GetAll().ToList();
            viewModel.Genres = GenreRepository.GetAll().ToList();

            if (orderBy == null || value == null)
            {
                viewModel.Shows = ShowRepository.GetAll().ToList();
                return View(viewModel);
            }
            else
            {
                if (orderBy == "Genre")
                {
                    var shows = ShowRepository.GetAll();
                    viewModel.Shows = shows.Where(i => i.GenreId == value).ToList();
                    return View(viewModel);
                }
                else if (orderBy == "Category")
                {
                    var shows = ShowRepository.GetAll();
                    viewModel.Shows = shows.Where(i => i.CategoryId == value).ToList();
                    return View(viewModel);
                }
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "Id", "Name");
            ViewBag.Genres = new SelectList(GenreRepository.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Show entity, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "shows", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            entity.Image = file.FileName;
            ShowRepository.AddShow(entity);
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "Id", "Name");
            ViewBag.Genres = new SelectList(GenreRepository.GetAll(), "Id", "Name");
            var show = ShowRepository.GetById(id);
            return View(show);
        }
        [HttpPost]
        public IActionResult Update(Show entity)
        {
            ShowRepository.UpdateShow(entity);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            ShowRepository.DeleteShow(id);
            return RedirectToAction("List");
        }


    }
}
