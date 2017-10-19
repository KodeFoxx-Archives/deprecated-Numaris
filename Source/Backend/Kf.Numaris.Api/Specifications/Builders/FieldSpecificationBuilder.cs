using System;
using System.Collections.Generic;
using System.Linq;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public sealed class FieldSpecificationBuilder : SpecificationBuilder<FieldSpecification, FieldSpecificationBuilder>
    {
        private readonly List<RuleSpecification> _ruleSpecifications = new List<RuleSpecification>();
        private readonly HashSet<string> _fieldDependencies = new HashSet<string>();

        public FieldSpecificationBuilder WithRule(RuleSpecification ruleSpecification)
            => SetField(() => _ruleSpecifications.Add(ruleSpecification));

        public FieldSpecificationBuilder DependsOnField<TFields>(TFields fieldName)
            => SetField(() => _fieldDependencies.Add(fieldName.ToString()));

        public override FieldSpecification Build()
            => new FieldSpecification(
                name: _name,
                ruleSpecifications: _ruleSpecifications,
                fieldDependencies: _fieldDependencies
            );
    }
}
