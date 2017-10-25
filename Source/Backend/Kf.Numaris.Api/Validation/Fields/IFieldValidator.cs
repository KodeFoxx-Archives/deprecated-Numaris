using System;
using System.Collections.Generic;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Fields
{
    public interface IFieldValidator<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        Identifier Identifier { get; }
        Identifier FieldSpecificationIdentifier { get; }
        IReadOnlyList<KeyValuePair<Identifier, Func<string[], IFieldValidationResult<TNumberSpecification>>>> FieldDependentValidators { get; }
        bool HasFieldDependencies { get; }
        IFieldValidationResult<TNumberSpecification> Validate(string input);
    }
}
