using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MovieApp.Data.Abstract
{
	public interface IGenreRepository
	{
		Genre GetById(int genreId);
		IQueryable<Genre> GetAll();
		void AddGenre(Genre entity);
		void UpdateGenre(Genre entity);
		void DeleteGenre(int genreId);

	}
}
