
using Orleans.Configuration;

namespace TwitchR.Silo.ModerationSilo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.AsOrleansSilo(silo =>
        {
            silo.Configure<SiloOptions>(opt =>
            {
                opt.SiloName = $"ModerationSilo_{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}";
            });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}
