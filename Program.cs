using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API_CRUD
{        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // Добавление необходимых сервисов для Swagger
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddOpenApiDocument();
                builder.Services.AddMvc();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Custom API", Version = "v1" });

                    
                });
     
                var app = builder.Build();

                // Включаем Swagger UI и OpenApi в режиме разработки
                if (app.Environment.IsDevelopment())
                {
                    app.UseOpenApi(options =>
                    {
                        options.Path = "/openapi/{documentName}.json";
                    });
                app.MapScalarApiReference(options =>
                {
                    // Fluent API
                    options
                        .WithTitle("Custom API")
                        .WithSidebar(false);

                    // Object initializer
                    options.Title = "Custom API";
                    options.ShowSidebar = false;
                });


                // Настройка Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Custom API v1");
                        c.RoutePrefix = "swagger"; // Путь для Swagger UI
                    });
                }

                // Стандартная конфигурация пайплайна
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                // Запуск приложения
                app.Run();
            }
        }
    }
