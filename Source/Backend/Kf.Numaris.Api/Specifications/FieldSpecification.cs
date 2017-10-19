using System.Collections.Generic;
using Kf.Numaris.Api.Specifications.Builders;

namespace Kf.Numaris.Api.Specifications
{
    public sealed class FieldSpecification : Specification
    {
        public static FieldSpecificationBuilder New()
            => new FieldSpecificationBuilder();

        private readonly List<RuleSpecification> _ruleSpecifications;
        public IReadOnlyCollection<RuleSpecification> FieldSpecifications => _ruleSpecifications.AsReadOnly();

        internal FieldSpecification(string name) : base(name) { }
    }
}
