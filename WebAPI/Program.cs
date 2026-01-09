using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddSingleton<DbConnectionFactory>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<UserService>();

        builder.Services.AddScoped<ProjectRepository>();
        builder.Services.AddScoped<ProjectService>();
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}