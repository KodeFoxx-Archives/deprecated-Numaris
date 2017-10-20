using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Fields
{
    public abstract class FieldFormatter<TFieldSpecification, TNumberSpecification> : IFieldFormatter
        where TFieldSpecification : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<IFieldFormatter>(GetType());

        public Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));

        public abstract string Format(string input);
    }
}
