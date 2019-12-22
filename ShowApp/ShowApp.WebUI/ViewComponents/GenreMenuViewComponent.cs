using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowApp.WebUI.ViewComponents
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
