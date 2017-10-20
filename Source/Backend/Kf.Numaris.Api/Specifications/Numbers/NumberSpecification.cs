using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Specifications.Numbers
{
    public abstract class NumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<INumberSpecification>(GetType());
    }
}
