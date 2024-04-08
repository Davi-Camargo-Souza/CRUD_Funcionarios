using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Interfaces;
using CRUD_Funcionarios.Persistence.Context;
using CRUD_Funcionarios.Persistence.Repositories;
using CRUD_Funcionarios.WebAPI.Services.Funcionario;
using CRUD_Funcionarios.WebAPI.Shared.Behavior;
using CRUD_Funcionarios.WebAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace CRUD_Funcionarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("CRUD_Funcionarios.WebAPI")));
            builder.Services.AddTransient(_ => new DapperContext(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();

            // Registra o serviço FuncionariosService
            builder.Services.AddScoped<FuncionariosServiceInterface, FuncionariosService>();

            // Registra o serviço IFuncionarioEntityInterceptor
            builder.Services.AddScoped<IFuncionarioEntityInterceptor, FuncionarioEntityInterceptor>();

            // Registra o validador FluentValidation
            builder.Services.AddControllers()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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
