using System.Reflection;

namespace StockPredicter.Api.Infrastructure
{
    public static class DIConfig
    {
        public static void RegisterComponents(this IServiceCollection services)
        {
            var domain = AppDomain.CurrentDomain.Load("StockPredicter.Domain");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(domain));
        }
    }
}
