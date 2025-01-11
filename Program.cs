using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API_CRUD
{        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // ���������� ����������� �������� ��� Swagger
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddOpenApiDocument();
                builder.Services.AddMvc();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Custom API", Version = "v1" });

                    
                });
     
                var app = builder.Build();

                // �������� Swagger UI � OpenApi � ������ ����������
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


                // ��������� Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Custom API v1");
                        c.RoutePrefix = "swagger"; // ���� ��� Swagger UI
                    });
                }

                // ����������� ������������ ���������
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                // ������ ����������
                app.Run();
            }
        }
    }
