using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Entity
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Show> Shows { get; set; }

	}
}
