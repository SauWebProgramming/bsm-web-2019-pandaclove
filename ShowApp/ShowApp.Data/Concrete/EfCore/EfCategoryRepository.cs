using ShowApp.Data.Abstract;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
{
	public class EfCategoryRepository : ICategoryRepository
	{
		private ApplicationDbContext context;
		public EfCategoryRepository(ApplicationDbContext _context)
		{
			context = _context;
		}
		public void AddCategory(Category entity)
		{
			context.Categories.Add(entity);
			context.SaveChanges();
		}

		public void DeleteCategory(int categoryId)
		{
			var category = context.Categories.FirstOrDefault(i => i.Id == categoryId);
			if (category != null)
			{
				context.Remove(category);
				context.SaveChanges();
			}
		}

		public IQueryable<Category> GetAll()
		{
			return context.Categories;
		}

		public Category GetById(int categoryId)
		{
			return context.Categories.FirstOrDefault(i => i.Id == categoryId);
		}

		public void UpdateCategory(Category entity)
		{
			context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}
	}
}
