using ShowApp.Data.Abstract;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
{
	public class EfGenreRepository : IGenreRepository
	{
		private ApplicationDbContext context;
		public EfGenreRepository(ApplicationDbContext _context)
		{
			context = _context;
		}
		public void AddGenre(Genre entity)
		{
			context.Genres.Add(entity);
			context.SaveChanges();
		}

		public void DeleteGenre(int genreId)
		{
			var genre = context.Genres.FirstOrDefault(i => i.Id == genreId);
			if (genre != null)
			{
				context.Genres.Remove(genre);
				context.SaveChanges();
			}
		}

		public IQueryable<Genre> GetAll()
		{
			return context.Genres;
		}

		public Genre GetById(int genreId)
		{
			return context.Genres.FirstOrDefault(i => i.Id == genreId);
		}

		public void UpdateGenre(Genre entity)
		{
			context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}
	}
}
