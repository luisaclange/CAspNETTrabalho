using APIDeslocamento.Data.Context;
using APIDeslocamento.Data.Repository;
using APIDeslocamento.Domain.Interfaces;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APIDeslocamento.WebAPI
{
    public class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            ///////// aqui inicia o que foi adicionado para o projeto
            ////adiciona o contexto aos serviços       
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ApplicationDbContext"),
                    b => b.MigrationsAssembly("APIDeslocamento.Data"));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var appAssemblie = typeof(
                APIDeslocamento.Application.Condutores.Commands.CriarCondutor.CriarCondutorCommand)
                .Assembly;
            builder.Services.AddMediatR(appAssemblie);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            ///////////////// fim


            builder.Services.AddMvc(setup => {
                // Implementação de código MVC...
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(appAssemblie));


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
