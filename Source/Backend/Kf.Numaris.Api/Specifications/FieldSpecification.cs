using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Specifications.Builders;

namespace Kf.Numaris.Api.Specifications
{
    public sealed class FieldSpecification : Specification
    {
        public static FieldSpecificationBuilder New()
            => new FieldSpecificationBuilder();

        private readonly List<RuleSpecification> _ruleSpecifications;
        public IReadOnlyCollection<RuleSpecification> RuleSpecifications => _ruleSpecifications.AsReadOnly();

        private readonly List<string> _fieldDependencies;
        public IReadOnlyCollection<string> FieldDependencies => _fieldDependencies.AsReadOnly();

        internal FieldSpecification(
            string name,
            IEnumerable<RuleSpecification> ruleSpecifications = null,
            IEnumerable<string> fieldDependencies = null)
            : base(name)
        {
            _ruleSpecifications = ruleSpecifications?.ToList() ?? new List<RuleSpecification>();
            _fieldDependencies = fieldDependencies?.ToList() ?? new List<string>();
        }
    }
}
