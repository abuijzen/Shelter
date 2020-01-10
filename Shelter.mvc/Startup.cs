using System;
using Shelter.shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace Shelter.mvc
{
	public class Startup
	{
		private readonly IConfiguration _config;
		private readonly string _connectionString;
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			//_connectionString = $@"Server={"db-server"}; Database={"shelter"}; User={"root"}; Password={"root"}; Port={"3306"}";
			_connectionString = $@"Server={"db-server"}; Database={"shelter"}; Uid={"root"}; Pwd={"root"}";
		}
		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			WaitForDBInit(_connectionString);
			services.AddMvc();
			services.AddControllersWithViews();
			services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
			services.AddScoped<IShelterDataAccess, ShelterDataAccess>();
			//services.AddDbContext<ShelterContext>(options => options.UseSqlite(Configuration.GetConnectionString("ShelterContext")));
			services.AddDbContext<ShelterContext>(options => options.UseMySql(_connectionString, builder =>
			{
				builder.MigrationsAssembly("Shelter.mvc");
				builder.EnableRetryOnFailure(
					maxRetryCount: 4,
					maxRetryDelay: TimeSpan.FromMilliseconds(2000),
					errorNumbersToAdd: null);
			})
			.EnableSensitiveDataLogging()
			.EnableDetailedErrors());

			services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
			services.AddScoped<IShelterDataAccess, ShelterDataAccess>();
			services.AddSwaggerGen(c =>
				{
					c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Shelter API", Version = "v1" });
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseInitializer databaseInitializer, ShelterContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shelter API");
					c.RoutePrefix = string.Empty;
				});
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			//databaseInitializer.Initialize();

			context.Database.Migrate();
		}


		// Try to connect to the db with exponential backoff on fail.
		private static void WaitForDBInit(string connectionString)
		{
			var connection = new MySqlConnection(connectionString);
			int retries = 1;
			while (retries < 7)
			{
				try
				{
					Console.WriteLine("Connecting to db-server. Trial: {0}", retries);
					connection.Open();
					connection.Close();
					break;
				}
				catch (MySqlException)
				{
					Thread.Sleep((int)Math.Pow(2, retries) * 1000);
					retries++;
				}
			}
		}
	}
}
