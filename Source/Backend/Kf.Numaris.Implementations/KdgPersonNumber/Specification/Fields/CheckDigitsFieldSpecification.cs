using Kf.Numaris.Api.Specifications.Field;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Specification.Fields
{
    public sealed class CheckDigitsFieldSpecification : FieldSpecification<KdgNumberSpecification>
    {
        public override int Order => 2;
    }
}
