﻿using System;
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

        private readonly List<KeyValuePair<Identifier, Func<string[], IFieldValidationResult<TNumberSpecification>>>> _fieldDependentValidators =
            new List<KeyValuePair<Identifier, Func<string[], IFieldValidationResult<TNumberSpecification>>>>();

        public Identifier Identifier
            => Identifier.For<IFieldValidator<TNumberSpecification>>(GetType());

        public Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));

        public abstract IFieldValidationResult<TNumberSpecification> Validate(string input);

        protected void AddFieldDependentValidator<TFieldSpecificationDependency>(Func<string[], IFieldValidationResult<TNumberSpecification>> validator)
            where TFieldSpecificationDependency : IFieldSpecification<TNumberSpecification>
        {
            _fieldDependentValidators.Add(new KeyValuePair<Identifier, Func<string[], IFieldValidationResult<TNumberSpecification>>>(
                Identifier.For<TFieldSpecificationDependency>(typeof(TFieldSpecification)),
                validator
            ));
        }

        protected IFieldValidationResult<TNumberSpecification> IsValid()
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true);
        protected IFieldValidationResult<TNumberSpecification> IsValidWithWarning(string message)
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(true, message);
        protected IFieldValidationResult<TNumberSpecification> IsNotValid(string message)
            => new FieldValidationResult<TFieldSpecification, TNumberSpecification>(false, message);

    }
}
