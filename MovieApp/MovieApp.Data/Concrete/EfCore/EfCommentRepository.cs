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
		public void AddComment(Comment comment)
		{
			throw new NotImplementedException();
		}

		public void DeleteComment(int userId)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Comment> GetAll()
		{
			throw new NotImplementedException();
		}

		public Comment GetById(int userId)
		{
			throw new NotImplementedException();
		}
	}
}
