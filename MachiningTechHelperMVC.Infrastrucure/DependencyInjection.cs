using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Infrastrucure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddTransient<IDrillRepository, DrillRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IDrillParametersRangeRepository, DrillParametersRangeRepository>();
            services.AddTransient<IDrillCheckedParametersRepository, DrillCheckedParametersRepository>();
            return services;
        }
    }
}
