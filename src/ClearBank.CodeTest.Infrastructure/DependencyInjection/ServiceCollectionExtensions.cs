using ClearBank.CodeTest.Infrastructure.Interfaces;
using ClearBank.CodeTest.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.CodeTest.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAccountDataStoreService, AccountDataStoreService>();
            services.AddTransient<IBackupAccountDataStoreService, BackupAccountDataStoreService>();

            return services;
        }
    }
}
