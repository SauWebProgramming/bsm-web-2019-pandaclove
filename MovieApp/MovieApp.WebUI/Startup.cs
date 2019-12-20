using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MovieApp.WebUI.Identity;

namespace MovieApp.WebUI
{
	public class Startup
	{
		public IConfiguration configuration { get; }
		public Startup(IConfiguration _configuration)
		{
			configuration = _configuration;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{


			//services.AddScoped<ICategoryRepository, EfCategoryRepository>();
			//services.AddScoped<IGenreRepository, EfGenreRepository>();
			//services.AddScoped<IShowRepository, EfShowRepository>();
			
			services.AddMvc();
		}
		public class ApplicationDbContext : DbContext
		{
			public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
			{

			}
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieDb;integrated security=true;");
			}
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseRouting();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
				Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
				RequestPath = "/modules"
			});//node_modules
			app.UseStatusCodePages();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
						name: "AdminRoute",
						pattern: "admin/{controller=Admin}/{action=Index}/{id?}"
				);
				endpoints.MapControllerRoute(
						name: "DefaultRoute",
						pattern: "{controller=Home}/{action=Index}/{id?}"
					);
			});
		}
	}
}
