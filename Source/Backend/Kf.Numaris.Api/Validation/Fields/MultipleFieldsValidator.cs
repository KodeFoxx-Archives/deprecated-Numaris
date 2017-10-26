using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Fields
{
    [DebuggerDisplay("{Identifier.Name} for #{FieldSpecificationIdentifiers.Count} fields")]
    public abstract class MultipleFieldsValidator<TNumberSpecification> : IMultipleFieldsValidator<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<IMultipleFieldsValidator<TNumberSpecification>>(GetType());

        public IReadOnlyList<Identifier> FieldSpecificationIdentifiers
            => FieldSpecifications.Select(fs => fs.Identifier).ToList();

        protected abstract IEnumerable<IFieldSpecification<TNumberSpecification>> FieldSpecifications { get; }

        public abstract IFieldValidationResult<TNumberSpecification> Validate(IEnumerable<KeyValuePair<Identifier, string>> input);

        protected IFieldValidationResult<TNumberSpecification> IsValid<TFieldSpecification>()
            where TFieldSpecification : IFieldSpecification<TNumberSpecification>
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true);
        protected IFieldValidationResult<TNumberSpecification> IsValidWithWarning<TFieldSpecification>(string message)
            where TFieldSpecification : IFieldSpecification<TNumberSpecification>
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true, message);
        protected IFieldValidationResult<TNumberSpecification> IsNotValid<TFieldSpecification>(string message)
            where TFieldSpecification : IFieldSpecification<TNumberSpecification>
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(false, message);
    }
}
