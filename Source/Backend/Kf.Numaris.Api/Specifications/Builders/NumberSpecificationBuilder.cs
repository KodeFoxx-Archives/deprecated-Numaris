using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public sealed class NumberSpecificationBuilder : SpecificationBuilder<NumberSpecification, NumberSpecificationBuilder>
    {
        private Func<string, string[]> _parseAlgorihm = _ => new List<string>().ToArray();
        private readonly HashSet<FieldSpecification> _fieldSpecifications = new HashSet<FieldSpecification>();

        public NumberSpecificationBuilder WithParseAlgorithm(Func<string, string[]> parseAlgorithm)
            => SetField(() => _parseAlgorihm = parseAlgorithm);

        public NumberSpecificationBuilder WithField(FieldSpecification fieldSpecification)
            => SetField(() => _fieldSpecifications.Add(fieldSpecification));

        public override NumberSpecification Build()
            => new NumberSpecification(
                name: _name,
                parseAlgorithm: _parseAlgorihm,
                fieldSpecifications: _fieldSpecifications.ToList()
            );
    }
}
