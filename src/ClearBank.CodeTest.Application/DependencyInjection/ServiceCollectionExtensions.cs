using ClearBank.CodeTest.Application.Factories;
using ClearBank.CodeTest.Application.Interfaces;
using ClearBank.CodeTest.Application.Models.Configuration;
using ClearBank.CodeTest.Application.Services;
using ClearBank.CodeTest.Application.Services.DataStore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.CodeTest.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddOptions<PaymentServiceSettings>().Bind(configuration.GetSection(nameof(PaymentServiceSettings))).ValidateDataAnnotations();

            services.AddTransient<AccountDataStore>();
            services.AddTransient<BackupAccountDataStore>();

            services.AddSingleton<IAccountValidation, AccountValidation>();
            services.AddSingleton<IDataStoreServiceFactory, DataStoreServiceFactory>();
            services.AddSingleton<IPaymentService, PaymentService>();

            return services;
        }
    }
}
