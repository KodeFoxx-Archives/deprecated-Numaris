using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Specifications.Builders;
using System;

namespace Kf.Numaris.Api.Specifications
{
    public sealed class NumberSpecification : Specification, INumberSpecification
    {
        public static NumberSpecificationBuilder New()
            => new NumberSpecificationBuilder();

        public Func<string, string[]> ParseAlgorithm { get; }

        private readonly List<FieldSpecification> _fieldSpecifications;
        public IReadOnlyCollection<FieldSpecification> FieldSpecifications => _fieldSpecifications.AsReadOnly();

        internal NumberSpecification(
            string name,
            Func<string, string[]> parseAlgorithm,
            IEnumerable<FieldSpecification> fieldSpecifications = null)
            : base(name)
        {
            ParseAlgorithm = parseAlgorithm;
            _fieldSpecifications = fieldSpecifications?.ToList() ?? new List<FieldSpecification>();
        }
    }
}