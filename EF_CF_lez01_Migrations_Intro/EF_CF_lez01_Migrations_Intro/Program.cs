
using EF_CF_lez01_Migrations_Intro.Models;
using EF_CF_lez01_Migrations_Intro.Repos;
using EF_CF_lez01_Migrations_Intro.Services;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_lez01_Migrations_Intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region configurazione del contesto

#if DEBUG
            builder.Services.AddDbContext<ContattoContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalServer")));
#else
            builder.Services.AddDbContext<ContattoContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("RemoteServer")));
#endif

            builder.Services.AddScoped<ContattoRepo>();
            builder.Services.AddScoped<ContattoService>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
