using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDrillService, DrillService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IDrillParametersRangeService, DrillParametersRangeService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
