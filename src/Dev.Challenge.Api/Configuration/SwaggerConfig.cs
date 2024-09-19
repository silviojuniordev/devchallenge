using Microsoft.OpenApi.Models;

namespace Dev.Challenge.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "API Challenge",
                    Description = "Esta API compoe o Desafio para Desenvolvedor .NET",
                    Contact = new OpenApiContact() { Name = "Silvio Stepheson", Email = "silviojuniordev@gmail.com" }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
