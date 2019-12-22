using ShowApp.Data.Abstract;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
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
