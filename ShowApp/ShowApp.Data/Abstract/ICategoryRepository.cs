using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Abstract
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
