using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Fields
{
    public abstract class FieldValidator<TFieldSpecification, TNumberSpecification> : IFieldValidator<TNumberSpecification>
        where TFieldSpecification : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<IFieldValidator<TNumberSpecification>>(GetType());

        public Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));

        public virtual IReadOnlyList<Identifier> FieldDependencyIdentifiers { get; }

        public bool HasFieldDependencies =>
            FieldDependencyIdentifiers != null && FieldDependencyIdentifiers.Count > 0;

        protected IReadOnlyList<IFieldSpecification<TNumberSpecification>> FieldSpecifications { get; }

        public FieldValidator(
            IEnumerable<IFieldSpecification<TNumberSpecification>> fieldSpecifications)
        {
            FieldSpecifications = fieldSpecifications?.ToList() ?? new List<IFieldSpecification<TNumberSpecification>>();
        }

        public abstract IPartialValidationResult Validate();
    }
}
