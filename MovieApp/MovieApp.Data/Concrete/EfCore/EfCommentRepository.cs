using MovieApp.Data.Abstract;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Concrete.EfCore
{
	public class EfCommentRepository : ICommentRepository
	{
		private ApplicationContext context;
		public EfCommentRepository(ApplicationContext _context)
		{
			context = _context;
		}
		public void AddComment(Comment entity)
		{
			context.Comments.Add(entity);
			context.SaveChanges();
		}

		public void DeleteComment(int commentId)
		{
			var comment = context.Comments.FirstOrDefault(i => i.Id == commentId);
			if(comment != null)
			{
				context.Comments.Remove(comment);
				context.SaveChanges();
			}
		}

		public IQueryable<Comment> GetAll()
		{
			return context.Comments;
		}

		public Comment GetById(int commentId)
		{
			return context.Comments.FirstOrDefault(i => i.Id == commentId);
		}
	}
}
