using HelloBank.Web.Api.Services.AccountCoreOperationService;
using HelloBank.Web.Api.Services.AccountTransactionService;

namespace HelloBank.Web.Api.Services;

public static class DomainServiceCollection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountCoreOperation, AccountCoreOperation>();

        services.AddScoped<IAccountTransaction, AccountTransaction>();

        return services;
    }
}