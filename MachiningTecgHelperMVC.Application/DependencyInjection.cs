using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Domain.Calculators;
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
            services.AddTransient<IDrillParametersRangeService, DrillParametersRangeService>();
            services.AddTransient<IDrillCheckedParametersService, DrillCheckedParametersService>();

            services.AddTransient<IProducerService, ProducerService>();

            services.AddTransient<ISimpleCalculatorLogic, SimpleCalculatorLogic>();

            services.AddTransient<ICostEstimationLogic, CostEstimationLogic>();

            services.AddTransient<ISolidMillingToolService, SolidMillingToolService>();
            services.AddTransient<ISolidMillingToolParametersRangeService, SolidMillingToolParametersRangeService>();
            services.AddTransient<ISolidMillingToolCheckedParametersService, SolidMillingToolCheckedParametersService>();

            services.AddTransient<IMillingInsertService, MillingInsertService>();
            services.AddTransient<IMillingInsertParametersRangeService, MillingInsertParametersRangeService>();
            services.AddTransient<IMillingToolService, MillingToolService>();
            services.AddTransient<IMillingToolMillingInsertService, MillingToolMillingInsertService>();
            services.AddTransient<IMillingToolCheckedParametersService, MillingToolCheckedParametersService>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
