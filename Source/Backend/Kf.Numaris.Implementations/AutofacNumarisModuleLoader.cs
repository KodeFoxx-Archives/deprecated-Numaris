using System.Linq;
using Autofac;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Implementations
{
    public abstract class NumarisAutofacModule<TNumberSpecification> : Module
        where TNumberSpecification : INumberSpecification
    {
        protected override void Load(ContainerBuilder builder)            
        {
            builder.RegisterAssemblyTypes(typeof(KdgNumberSpecification).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(INumberFormatter<TNumberSpecification>)))
                .Where(t => t.IsClass)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(KdgNumberSpecification).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(IFieldSpecification<TNumberSpecification>)))
                .Where(t => t.IsClass)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(KdgNumberSpecification).Assembly)
                .Where(t => t.GetInterfaces().Contains(typeof(IFieldFormatter<TNumberSpecification>)))
                .Where(t => t.IsClass)
                .AsImplementedInterfaces();
        }
    }
}
