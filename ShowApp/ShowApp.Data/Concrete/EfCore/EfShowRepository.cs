using ShowApp.Data.Abstract;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
{
	public class EfShowRepository : IShowRepository
	{
		private ApplicationDbContext context;
		public EfShowRepository(ApplicationDbContext _context)
		{
			context = _context;
		}
		public void AddShow(Show entity)
		{
			context.Shows.Add(entity);
			context.SaveChanges();
		}

		public void DeleteShow(int showId)
		{
			var show = context.Shows.FirstOrDefault(i => i.Id == showId);
			if (show != null)
			{
				context.Remove(show);
				context.SaveChanges();
			}
		}

		public IQueryable<Show> GetAll()
		{
			return context.Shows;
		}

		public Show GetById(int showId)
		{
			return context.Shows.FirstOrDefault(i => i.Id == showId);
		}

		public void UpdateShow(Show entity)
		{
			context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}
	}
}
