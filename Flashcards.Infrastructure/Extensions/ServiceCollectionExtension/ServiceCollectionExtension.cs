using Flashcards.Infrastructure.Presistence.FlashcardsDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Extensions.ServiceCollectionExtension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlashcardsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FlashcardsApiDb")));

            return services;
        }
    }
}
