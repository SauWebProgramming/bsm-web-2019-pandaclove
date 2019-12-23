using Microsoft.AspNetCore.Identity;
using ShowApp.Data.Concrete.EfCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowApp.WebUI.Models
{
	public class RoleDetails
	{
		public IdentityRole Role { get; set; }
		public IEnumerable<AppUser> Members { get; set; }
		public IEnumerable<AppUser> NonMembers { get; set; }
	}

	public class RoleEditModel
	{
		public string RoleId { get; set; }
		public string RoleName { get; set; }
		public string[] IdsToAdd { get; set; }
		public string[] IdsToDelete { get; set; }
	}
}
