using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KolmeoProducts.Data;
using KolmeoProducts.Services.Product;
using Microsoft.OpenApi.Models;

namespace KolmeoProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        services.AddControllers();
                        services.AddScoped<IProductService, ProductService>();
                        services.AddDbContext<ProductDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("KolmeoProductDB");
                        });

                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
                        });
                    });

                    webBuilder.Configure((hostBuilderContext, app) =>
                    {
                        var env = hostBuilderContext.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            // Add production-specific error handling middleware
                            app.UseExceptionHandler("/Error");
                            app.UseHsts();
                        }

                        app.UseRouting();

                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
                        });

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
