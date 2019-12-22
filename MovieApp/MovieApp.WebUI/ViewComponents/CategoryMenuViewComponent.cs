﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.WebUI.ViewComponents
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
