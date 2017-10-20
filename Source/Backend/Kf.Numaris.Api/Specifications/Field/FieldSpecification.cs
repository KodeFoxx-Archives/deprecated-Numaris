using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Specifications.Field
{
    public class FieldSpecification<TNumberSpecification> : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.FromType<IFieldSpecification<TNumberSpecification>>(GetType());

        public Identifier NumberSpecificationIdentifier
            => Identifier.FromType<INumberSpecification>(typeof(TNumberSpecification));
    }
}
