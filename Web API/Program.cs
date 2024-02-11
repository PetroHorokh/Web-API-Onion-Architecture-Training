using Core;
using Core.Services.Abstract;
using Data;
using Infrastructure.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers()
        .AddApplicationPart(typeof(AccountController).Assembly)
        .AddApplicationPart(typeof(OwnerController).Assembly);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog();

    builder.Services.AddDbContext<OnionDbContext>(
        opts => opts.UseSqlServer(
            builder.Configuration.GetConnectionString("OnionDB")!,
            b => b.MigrationsAssembly("Data")));

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddTransient<IOwnerService, OwnerService>();
    builder.Services.AddTransient<IAccountService, AccountService>();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

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
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
