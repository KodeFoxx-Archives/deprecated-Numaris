using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Fields
{
    [DebuggerDisplay("{Identifier.Name} for field '{FieldSpecificationIdentifier.Name}'")]
    public abstract class FieldValidator<TFieldSpecification, TNumberSpecification> : IFieldValidator<TNumberSpecification>
        where TFieldSpecification : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<IFieldValidator<TNumberSpecification>>(GetType());

        public Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));

        public abstract IFieldValidationResult<TNumberSpecification> Validate(string input);        

        protected IFieldValidationResult<TNumberSpecification> IsValid()
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true);
        protected IFieldValidationResult<TNumberSpecification> IsValidWithWarning(string message)
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true, message);
        protected IFieldValidationResult<TNumberSpecification> IsNotValid(string message)
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(false, message);
    }
}
