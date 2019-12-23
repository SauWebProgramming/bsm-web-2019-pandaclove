using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore.Identity
{
	public class AppUser : IdentityUser
	{
		public string Image { get; set; }

	}
}
