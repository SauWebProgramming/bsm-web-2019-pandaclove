using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using System.Linq;
namespace MovieApp.Data.Abstract
{
	public interface IShowRepository
	{
		Show GetById(int showId);
		IQueryable<Show> GetAll();
		void AddShow(Show entity);
		void UpdateShow(Show entity);
		void DeleteShow(int showId);
		IQueryable<Comment> GetComments(int showId);


	}
}
