using Kf.Numaris.Api.Specifications.Field;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification.Fields
{
    public sealed class CheckDigitsFieldSpecification : FieldSpecification<KdgNumberSpecification>
    {
        public override int Order => 2;
    }
}
