using Microsoft.EntityFrameworkCore;
using ShowApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Data.Concrete.EfCore
{
	public class ApplicationDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;");
		}
		public DbSet<Show> Shows { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<UserRoles> UserRoles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}
