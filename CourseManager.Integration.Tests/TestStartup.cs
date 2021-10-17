using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseManager.Integration.Tests
{
  public class TestStartup : Startup
  {
    public new IConfiguration Configuration { get; }

    public TestStartup(IConfiguration configuration) : base(configuration)
    {
      Configuration = configuration;
    }
    protected override void ConfigSpa(IApplicationBuilder app, IWebHostEnvironment env) {}
    protected override void AddSpaServices(IServiceCollection services){}
  }
}
