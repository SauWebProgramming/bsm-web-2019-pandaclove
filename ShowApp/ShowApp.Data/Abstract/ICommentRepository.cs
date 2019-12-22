using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ShowApp.Data.Abstract
{
	public interface ICommentRepository
	{
		Comment GetById(int userId);
		IQueryable<Comment> GetAll();
		void AddComment(Comment comment);
		void DeleteComment(int userId);
	}
}
