using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Fields
{
    public sealed class CheckDigitsFieldSpecification : FieldSpecification<KdgNumberSpecification>
    {
        public override int Order => 2;
    }
}
