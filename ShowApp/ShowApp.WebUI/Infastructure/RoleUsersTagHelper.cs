using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShowApp.Data.Concrete.EfCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowApp.WebUI.Infastructure
{
	[HtmlTargetElement("td",Attributes = "identity-role")]
	public class RoleUsersTagHelper : TagHelper
	{
		private UserManager<AppUser> UserManager;
		private RoleManager<IdentityRole> RoleManager;
		public RoleUsersTagHelper(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager )
		{
			UserManager = userManager;
			RoleManager = roleManager;
		}
		[HtmlAttributeName("identity-role")]
		public string Role { get; set; }

		public  override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			List<string> names = new List<string>();
			var role = await RoleManager.FindByIdAsync(Role);
			if(role != null)
			{
				foreach (var user in UserManager.Users)
				{
					if (user != null && await UserManager.IsInRoleAsync(user, role.Name))
					{
						names.Add(user.UserName);
					}
				}
			}
			output.Content.SetContent(names.Count == 0 ? "No User" : string.Join(", ", names));
		}
	}
}
