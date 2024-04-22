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
            services.AddTransient<IProducerRepository, ProducerRepository>();

            services.AddTransient<IDrillRepository, DrillRepository>();
            services.AddTransient<IDrillParametersRangeRepository, DrillParametersRangeRepository>();
            services.AddTransient<IDrillCheckedParametersRepository, DrillCheckedParametersRepository>();

            services.AddTransient<IMillingInsertRepository, MillingInsertRepository>();
            services.AddTransient<IMillingToolRepository, MillingToolRepository>();
            services.AddTransient<IMillingInsertParametersRangeRepository, MillingInsertParametersRangeRepository>();
            services.AddTransient<IMillingToolCheckedParametersRepository, MillingToolCheckedParametersRepository>();

            services.AddTransient<ISolidMillingToolRepository, SolidMillingToolRepository>();
            services.AddTransient<ISolidMillingToolParametersRangeRepository, SolidMillingToolParametersRangeRepository>();
            services.AddTransient<ISolidMillingToolCheckedParametersRepository, SolidMillingToolCheckedParametersRepository>();
            return services;
        }
    }
}
