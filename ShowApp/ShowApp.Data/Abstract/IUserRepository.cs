﻿using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowApp.Data.Abstract
{
	public interface IUserRepository
	{
		User GetById(int userId);
		IQueryable<User> GetAll();
		void AddUser(User entity);
		void UpdateUser(User entity);
		void DeleteUser(int userId);
	}
}
