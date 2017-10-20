using System.Collections.Generic;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Numbers
{
    public abstract class NumberValidator<TNumberSpecification> : INumberValidator<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<INumberValidator<TNumberSpecification>>(GetType());

        protected IReadOnlyList<IFieldValidator<TNumberSpecification>> FieldValidators { get; }

        public abstract IValidationResult Validate();
    }
}
