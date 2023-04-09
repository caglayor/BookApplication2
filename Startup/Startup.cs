using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Humanizer.Configuration;
using BookApplication2.Data;



public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // ...
}


namespace BookApplication2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
    //        services.AddDbContext<ApplicationDbContext>(options =>
    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        public void Configure(IApplicationBuilder app)
        {
            // Uygulama önyükleme ayarlarını yapılandırın
        }
    }


  

}

