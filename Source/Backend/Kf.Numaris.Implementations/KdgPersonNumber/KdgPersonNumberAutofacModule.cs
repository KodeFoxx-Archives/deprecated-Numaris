using Autofac;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Implementations.KdgPersonNumber.Fields;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Implementations.KdgPersonNumber
{
    public class KdgPersonNumberAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KdgNumberFormatter>().As<INumberFormatter<KdgNumberSpecification>>();
            builder.RegisterType<CheckDigitsFieldSpecification>().As<IFieldSpecification<KdgNumberSpecification>>();
            builder.RegisterType<PersonNumberFieldSpecification>().As<IFieldSpecification<KdgNumberSpecification>>();
            builder.RegisterType<PersonNumberFieldFormatter>().As<IFieldFormatter<KdgNumberSpecification>>();
            builder.RegisterType<CheckDigitsFieldFormatter>().As<IFieldFormatter<KdgNumberSpecification>>();
        }
    }
}
