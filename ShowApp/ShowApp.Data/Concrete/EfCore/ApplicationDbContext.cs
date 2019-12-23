using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowApp.Data.Concrete.EfCore.Identity;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;MultipleActiveResultSets=true;");
		}
		public DbSet<Show> Shows { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}
