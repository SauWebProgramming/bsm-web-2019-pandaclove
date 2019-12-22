using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Entity
{
	public class UserRoles
	{
		public int Id { get; set; }
		public string Role { get; set; }
		public List<User> Users { get; set; }

	}
}
