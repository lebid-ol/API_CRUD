using Scalar.AspNetCore;
using Microsoft.OpenApi.Models;

namespace API_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApiDocument();


            var app = builder.Build();


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
            }

            void ConfigureServices(IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDevoTo", Version = "v1" });
                });
            }

            void Configure(IApplicationBuilder app,
                      IWebHostEnvironment env)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                  "WebApiDevoTo v1"));
            }


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            app.Run();



        }
    }
}
