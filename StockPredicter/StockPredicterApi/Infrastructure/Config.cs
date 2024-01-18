using StockPredicter.Domain.Dto.Utility;

namespace StockPredicter.Api.Infrastructure
{
    public static class Config
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5000",
                                            "https://localhost:5001",
                                            "http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials();
                    });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.RegisterComponents();
            services.AddSingleton(configuration.GetSection("PolygonApiConfig").Get<PolygonApiConfig>());

            return services;
        }
    }
}
