using Microsoft.EntityFrameworkCore;
using Test.DAL;
using Test.DAL.Abstracts;
using Test.DAL.Repositories;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection"))
			);
			builder.Services.AddRazorPages();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
			builder.Services.AddScoped<IBookRepository, BookRepository>();
			builder.Services.AddScoped<Test.Services.AuthorService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}