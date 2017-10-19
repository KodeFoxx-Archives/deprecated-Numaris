using System;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public sealed class RuleSpecificationBuilder : SpecificationBuilder<RuleSpecification, RuleSpecificationBuilder>
    {
        private Func<string, string, bool> _algorithm = (otherField, thisField) => false;

        public RuleSpecificationBuilder WithAlgorithm(Func<string, string, bool> algorithm)
            => SetField(() => _algorithm = algorithm);

        public override RuleSpecification Build()
            => new RuleSpecification(
                name: _name,
                algorithm: _algorithm
            );
    }
}
