using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Abstract
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
