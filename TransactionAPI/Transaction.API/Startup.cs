using Microsoft.EntityFrameworkCore;
using Transaction.Application.Services;
using Transaction.Application.Services.Interfaces;
using Transaction.Infra.Data;
using Transaction.Infra.Repositories;
using Transaction.Infra.Repositories.Interfaces;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TransactionDb"));

        services.AddScoped<ITradeRepository, TradeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITradeService, TradeService>();
        services.AddScoped<IUserService, UserService>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Transaction API");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}