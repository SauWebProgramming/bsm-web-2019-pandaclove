using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Abstract
{
	public interface ICommentRepository
	{
		Comment GetById(int commentId);
		IQueryable<Comment> GetAll();
		void AddComment(Comment entity);
		void DeleteComment(int commentId);

	}
}
