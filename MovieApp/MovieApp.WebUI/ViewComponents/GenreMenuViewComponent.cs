using Microsoft.AspNetCore.Mvc;
using MovieApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.WebUI.ViewComponents
{
	public class GenreMenuViewComponent : ViewComponent
	{
		private IGenreRepository Repository;
		public GenreMenuViewComponent(IGenreRepository repository)
		{
			Repository = repository;
		}
		public IViewComponentResult Invoke()
		{
			return View(Repository.GetAll());
		}
	}
}
