﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Entity
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Show> Shows { get; set; }
	}
}
