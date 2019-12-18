using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Entity
{
	public class GenreShow
	{
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public int ShowId { get; set; }
		public Show Show { get; set; }

	}
}
