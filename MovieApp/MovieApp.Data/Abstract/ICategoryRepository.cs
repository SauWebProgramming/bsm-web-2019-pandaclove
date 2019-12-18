using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using System.Linq;
namespace MovieApp.Data.Abstract
{
	public interface ICategoryRepository
	{
		Category GetById(int categoryId);
		IQueryable<Category> GetAll();
		void AddCategory(Category entity);
		void UpdateCategory(Category entity);
		void DeleteCategory(int categoryId);

	}
}
