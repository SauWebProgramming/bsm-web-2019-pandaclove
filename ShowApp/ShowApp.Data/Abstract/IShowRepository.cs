using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Abstract
{
	public interface IShowRepository
	{
		Show GetById(int showId);
		IQueryable<Show> GetAll();
		void AddShow(Show entity);
		void UpdateShow(Show entity);
		void DeleteShow(int showId);
	}
}
