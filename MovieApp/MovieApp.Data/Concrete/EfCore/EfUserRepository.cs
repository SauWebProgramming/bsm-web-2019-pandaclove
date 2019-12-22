using MovieApp.Data.Abstract;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Concrete.EfCore
{
	public class EfUserRepository : IUserRepository
	{
		public void AddUser(User entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(int userId)
		{
			throw new NotImplementedException();
		}

		public IQueryable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User GetById(int userId)
		{
			throw new NotImplementedException();
		}

		public void UpdateUser(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
