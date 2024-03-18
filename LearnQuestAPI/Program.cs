using LearnQuestAPI.Data;
using LearnQuestAPI.Repository.Interface;
using LearnQuestAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI
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

            // Informa qual banco será utilizado e qual string de conexão buscar 
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<LearnQuestDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

            //Injeção de Dependencia
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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