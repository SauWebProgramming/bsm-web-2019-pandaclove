using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Abstract
{
	public interface ICommentRepository
	{
		Comment GetById(int userId);
		IQueryable<Comment> GetAll();
		void AddComment(Comment comment);
		void DeleteComment(int userId);
	}
}
