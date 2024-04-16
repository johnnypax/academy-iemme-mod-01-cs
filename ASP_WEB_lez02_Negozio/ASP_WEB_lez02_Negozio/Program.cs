using ASP_WEB_lez02_Negozio.Models;
using ASP_WEB_lez02_Negozio.Repositories;
using ASP_WEB_lez02_Negozio.Services;
using Microsoft.EntityFrameworkCore;

namespace ASP_WEB_lez02_Negozio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AccLez06NegozioContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Locale")
                    )
                );
            builder.Services.AddScoped<ProdottoRepository>();
            builder.Services.AddScoped<ProdottoService>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Prodotto}/{action=Lista}/{varCodice?}");

            app.Run();
        }
    }
}
