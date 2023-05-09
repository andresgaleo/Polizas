using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPolizasService, PolizasService>();
            services.AddScoped<IPolizasRepository, PolizaRepository>();
        }
    }
}
