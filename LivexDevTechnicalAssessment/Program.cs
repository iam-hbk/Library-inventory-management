using LivexDevTechnicalAssessment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

//Entity Framework Package for PostgreSQL
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Text.Json.Serialization;

namespace LivexDevTechnicalAssessment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});


			//Adding CORS support
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAnyOrigin",
			builder => builder.AllowAnyOrigin()  // For demonstration purposes only
							  .AllowAnyMethod()
							  .AllowAnyHeader());
			});


			//Registering the Database context to the builder
			builder.Services.AddDbContext<AppDbContext>(
				options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
				);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCors("AllowReactApp");
			app.UseRouting();
			app.UseAuthorization();


			/*
             * There is a warning suggesting I create a local variable for this middleware
             * but the documentationn doesn't say anything in that regard and confirms that
             * this is a void function so no return value is expected.
             */
#pragma warning disable ASP0014
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();  // Map the API controllers
				app.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);
			});
#pragma warning restore ASP0014




			app.Run();
		}

	}
}