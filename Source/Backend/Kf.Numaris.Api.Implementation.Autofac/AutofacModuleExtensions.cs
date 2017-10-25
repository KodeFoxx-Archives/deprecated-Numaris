using System.Linq;
using Autofac;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Implementation.Autofac
{
    public static class AutofacModuleExtensions
    {
        public static void RegisterAssemblyTypesWithClassImplementations<TNumberSpecification, TToRegister>(this ContainerBuilder builder)
            where TNumberSpecification : INumberSpecification
        {
            builder.RegisterAssemblyTypes(typeof(TNumberSpecification).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(TToRegister)))
                .Where(t => t.IsClass)
                .AsImplementedInterfaces();
        }
    }
}
