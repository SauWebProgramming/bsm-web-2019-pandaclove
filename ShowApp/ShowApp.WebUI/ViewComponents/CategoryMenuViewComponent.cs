using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowApp.WebUI.ViewComponents
{
	public class CategoryMenuViewComponent : ViewComponent
	{
		private ICategoryRepository Repository;
		public CategoryMenuViewComponent(ICategoryRepository repository)
		{
			Repository = repository;
		}
		public IViewComponentResult Invoke()
		{
			return View(Repository.GetAll());
		}
	}
}
