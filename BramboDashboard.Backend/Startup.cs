using System;
using System.Threading;
using BramboDashboard.Backend.API.Configurations;
using BramboDashboard.Backend.API.Services;
using BramboDashboard.Backend.API.Services.Contracts;
using BramboDashboard.Backend.DAL;
using BramboDashboard.Backend.DAL.Repository;
using BramboDashboard.Backend.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BramboDashboard.Backend.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      var connectionString =
        Environment.GetEnvironmentVariable(
          "BramboDashboardDbProd") ?? // Probeer te vinden via env variabelen haal hem anders uit appsettings
        Configuration.GetConnectionString("BramboDashboardDbLocal");

      Console.WriteLine("################### Connection string ###################");
      Console.WriteLine($"connectionString = {connectionString}");
      services.AddDbContext<SportschoolVanDrunenDbContext>(options => options.UseSqlServer(connectionString));

      services.AddTransient(x => AutoMapperConfig.GetConfiguration().CreateMapper());
      // DI -Repositories

      services.AddTransient<IClientRepository, ClientRepository>();
      services.AddTransient<IWeightRepository, WeightRepository>();

      // DI - Services
      services.AddTransient<IClientService, ClientService>();
      services.AddTransient<IMeasurementService, MeasurementService>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info {Title = "Brambo Dashboard API", Version = "v1"});
      });

      services.AddCors();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        Console.WriteLine("################# Create Database");
        EnsureCreated(serviceScope); // Methode die wacht met aanmaken omdat we een vertraging kunnen hebben
        serviceScope.ServiceProvider.GetService<SportschoolVanDrunenDbContext>().Database
          .EnsureCreated(); // DB "aanmaken"
//        serviceScope.ServiceProvider.GetService<SportschoolVanDrunenDbContext>().EnsureSeeded();            // DB "seeden"
      }

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

      app.UseCors(
        options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
      );

      app.UseMvc();
    }

    /// <summary>
    /// Gebruiken we om problemen met DB creatie te voorkomen.
    /// </summary>
    /// <param name="serviceScope"></param>
    private static void EnsureCreated(IServiceScope serviceScope)
    {
      for (var i = 1; i <= 5; i++)
      {
        try
        {
          Console.WriteLine($"Attempt ({i}/5) to ensure database has been created...");
          serviceScope.ServiceProvider.GetService<SportschoolVanDrunenDbContext>().Database
            .EnsureCreated();
          break;
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
          if (i == 5)
          {
            throw e;
          }
        }

        Console.WriteLine("Wait 6 seconds for next attempt...");
        Thread.Sleep(6000);
      }
    }
  }
}