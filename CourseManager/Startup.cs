using CourseManager.DataBase.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CourseManager
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
      services.AddControllersWithViews().AddNewtonsoftJson();
      services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
      AddSpaServices(services);
      services.AddDependencyServices();
      ConfigureDb(services);
      services.AddSwaggerGen();
    }

    protected virtual void ConfigureDb(IServiceCollection services)
    {
      services.AddDbContext<CourseManagerDbContext>(options =>
      {
        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BrunoEstudos;Trusted_Connection=True;MultipleActiveResultSets=true");
      });
    }

    protected virtual void AddSpaServices(IServiceCollection services)
    {
      // In production, the React files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/public";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseSwagger();

      app.UseSwaggerUI();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
      });
      ConfigSpa(app, env);
      MigrateDB(app);
    }

    protected virtual void MigrateDB(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<CourseManagerDbContext>();
        context.Database.Migrate();
      }
    }

    protected virtual void ConfigSpa(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseStaticFiles();
      app.UseSpaStaticFiles();
      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });
    }
  }
}
