using Conta.Application.Mappings;
using Conta.Application.Services;
using Conta.Application.Services.Interfaces;
using Conta.Domain.Repositories;
using Conta.Infra.Data.Context;
using Conta.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conta.IoC;

public static class DependecyInjection
{
    public static IServiceCollection ResolveDependecy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));  
        });

        services.AddDbContext<ApplicationDbContext>();
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        
        services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        services.AddScoped<IExtratoService, ExtratoService>();
        services.AddScoped<ITransacaoService, TransacaoService>();      

        return services;
    }
}