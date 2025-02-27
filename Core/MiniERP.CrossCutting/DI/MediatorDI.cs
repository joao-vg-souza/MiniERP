using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MiniERP.CrossCutting.DI
{
    public static class MediatorDI
    {
        public static void AddBus(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
        {
            var assemblies = new List<Assembly>();

            var mediatorConfigAssembly = Assembly.GetAssembly(typeof(MediatorDI));
            if (mediatorConfigAssembly != null)
            {
                assemblies.Add(mediatorConfigAssembly);
            }

            foreach (Type handler in handlerAssemblyMarkerTypes)
            {
                var assembly = Assembly.GetAssembly(handler);
                if (assembly != null && !assemblies.Contains(assembly))
                {
                    assemblies.Add(assembly);
                }
            }

            services.AddMediatR(o =>
            {
                o.RegisterServicesFromAssemblies(assemblies.Distinct().ToArray());
            });

            services.AddScoped<Infra.Bus.IMediator, Infra.Bus.Handlers.Mediator>();
            //services.AddValidations(handlerAssemblyMarkerTypes);
        }

        /*private static void AddValidations(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
        {
            Type validatableType = typeof(IValidateableCommand<>);
            IEnumerable<Type> enumerable = from p in handlerAssemblyMarkerTypes.Select((Type x) => x.Assembly).Distinct().SelectMany((Assembly s) => s.GetTypes())
                    .ToArray()
                                           where !p.IsInterface && !p.IsAbstract && !p.IsGenericType && validatableType.IsSubclassOfRawGenericInterface(p)
                                           select p;
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            foreach (Type item in enumerable)
            {
                if (serviceProvider.GetService(typeof(Validator<>).MakeGenericType(item)) != null)
                {
                    Type type = (from x in item.GetInterfaces()
                                 where x.IsGenericType
                                 select x).First().GetGenericArguments().First();
                    Type type2 = typeof(Response<>).MakeGenericType(type);
                    Type serviceType = typeof(IPipelineBehavior<,>).MakeGenericType(item, type2);
                    Type implementationType = typeof(ValidationBehaviour<,>).MakeGenericType(item, type);
                    services.AddTransient(serviceType, implementationType);
                }
            }
        }*/
    }
}
