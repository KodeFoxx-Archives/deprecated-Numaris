using Autofac;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Implementation.Autofac
{
    public abstract class NumarisAutofacModule<TNumberSpecification> : Module
        where TNumberSpecification : INumberSpecification
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadGenericNumarisTypes(builder);
            LoadSpecificTypes(builder);
        }

        protected void LoadGenericNumarisTypes(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypesWithClassImplementations<TNumberSpecification, INumberFormatter<TNumberSpecification>>();
            builder.RegisterAssemblyTypesWithClassImplementations<TNumberSpecification, IFieldSpecification<TNumberSpecification>>();
            builder.RegisterAssemblyTypesWithClassImplementations<TNumberSpecification, IFieldFormatter<TNumberSpecification>>();
            builder.RegisterAssemblyTypesWithClassImplementations<TNumberSpecification, IStringParser<TNumberSpecification>>();            
        }

        protected virtual void LoadSpecificTypes(ContainerBuilder builder)
        {
        }
    }
}
