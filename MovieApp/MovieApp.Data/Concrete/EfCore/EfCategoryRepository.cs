using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApp.Data.Abstract;
using MovieApp.Entity;

namespace MovieApp.Data.Concrete.EfCore
{
	class EfCategoryRepository : ICategoryRepository
	{
		private AppContext context;
		public EfCategoryRepository(AppContext _context)
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
			if(category != null)
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
