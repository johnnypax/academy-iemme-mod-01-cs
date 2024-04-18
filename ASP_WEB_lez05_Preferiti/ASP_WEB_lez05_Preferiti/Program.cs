using ASP_WEB_lez05_Preferiti.Repositories;
using ASP_WEB_lez05_Preferiti.Services;

namespace ASP_WEB_lez05_Preferiti
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<FilmRepository>();
            builder.Services.AddScoped<FilmService>();

            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(3); });

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
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Film}/{action=Index}/{cod?}");

            app.Run();
        }
    }
}
