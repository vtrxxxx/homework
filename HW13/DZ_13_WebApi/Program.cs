using DZ_13_WebApi.Middleware;
using DZ_13_WebApi.Modules;
using CorrelationId.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Versioning;
using CorrelationId;


namespace HW12
{
    public class Program
    {
        const int error404 = 404;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddApiVersioning(t =>
            {
                t.ApiVersionReader = new UrlSegmentApiVersionReader();
                t.ReportApiVersions = true;
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddCore(builder.Configuration);
            builder.Services.AddLogging();
            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            });
            builder.Services.AddDefaultCorrelationId();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies and Sessions List API V1");
                    c.OAuthAppName("Movies and Sessions List API");
                });
            }
            app.UseCorrelationId();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseHttpLogging();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
