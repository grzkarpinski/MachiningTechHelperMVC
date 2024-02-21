using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTecgHelperMVC.Application.Mapping
{
    // auto mapper profile configuration
    // this class is used to autmate the mapping of the domain model to the view model
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                                   .Where(i => i.IsGenericType)
                                                      .Any(i => i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
                methodInfo.Invoke(instance, new object[] { this });
            }
        }
    }
}
