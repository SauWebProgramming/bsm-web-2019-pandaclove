using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
namespace MovieApp.Data.Concrete.EfCore
{
	public class AppContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GenreShow>()
				.HasKey(k => new { k.GenreId, k.ShowId });
		}
		public DbSet<Show> Shows { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Genre> Genres { get; set; }

	}
}
