using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Concrete.EfCore
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;");
		}
		public DbSet<Show> Shows { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}
