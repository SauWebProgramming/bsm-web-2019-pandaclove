using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Entity
{
	public class User
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public UserRoles Role { get; set; }
		public List<Comment> Comments { get; set; }
		public string Image { get; set; }
	}
}
