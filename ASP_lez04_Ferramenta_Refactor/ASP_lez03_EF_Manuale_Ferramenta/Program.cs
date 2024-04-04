
using ASP_lez03_EF_Manuale_Ferramenta.Models;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;
using ASP_lez03_EF_Manuale_Ferramenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ASP_lez03_EF_Manuale_Ferramenta
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

            #region Importanti per la configurazione di Context e Repository
            builder.Services.AddDbContext<FerramentaContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<IRepo<Prodotto>, ProdottoRepo>();
            builder.Services.AddScoped<ProdottoService>();

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
