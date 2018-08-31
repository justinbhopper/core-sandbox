using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Core;
using Swashbuckle.AspNetCore.Swagger;

namespace Sandbox.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<SandboxDbContext>(opt => 
				opt.UseInMemoryDatabase("Sandbox"));
			
			services.AddMvc()
				.AddControllersAsServices()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Sandbox Api", Version = "v1" });
			});

			var builder = new ContainerBuilder();
			
			builder.Populate(services);
			
			return new AutofacServiceProvider(builder.Build());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseSwagger();

			app.UseSwaggerUI(c => 
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sandbox Api");
				c.RoutePrefix = string.Empty; // Serve swagger at root of website
			});

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
