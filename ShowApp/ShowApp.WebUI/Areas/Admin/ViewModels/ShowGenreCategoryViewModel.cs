using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowApp.WebUI.Areas.Admin.ViewModels
{
	public class ShowGenreCategoryViewModel
	{
		public List<Show> Shows { get; set; }
		public List<Category> Categories { get; set; }
		public List<Genre> Genres { get; set; }
	}
}
