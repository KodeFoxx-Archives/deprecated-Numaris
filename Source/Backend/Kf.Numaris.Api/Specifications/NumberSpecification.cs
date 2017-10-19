using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Specifications.Builders;

namespace Kf.Numaris.Api.Specifications
{
    public sealed class NumberSpecification : Specification, INumberSpecification
    {
        public static NumberSpecificationBuilder New()
            => new NumberSpecificationBuilder();

        private readonly List<FieldSpecification> _fieldSpecifications;
        public IReadOnlyCollection<FieldSpecification> FieldSpecifications => _fieldSpecifications.AsReadOnly();

        internal NumberSpecification(
            string name,
            IEnumerable<FieldSpecification> fieldSpecifications = null)
            : base(name)
            => _fieldSpecifications = fieldSpecifications?.ToList() ?? new List<FieldSpecification>();
    }
}