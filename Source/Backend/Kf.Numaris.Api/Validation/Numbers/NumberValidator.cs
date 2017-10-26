using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Numbers
{
    [DebuggerDisplay("{Identifier.Name}")]
    public abstract class NumberValidator<TNumberSpecification> : INumberValidator<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<INumberValidator<TNumberSpecification>>(GetType());

        protected IReadOnlyDictionary<int, IFieldValidator<TNumberSpecification>> FieldValidators { get; }
        protected IReadOnlyList<IFieldValidator<TNumberSpecification>> OrderedFieldValidators
            => FieldValidators
                .Where(fv => fv.Value != null)
                .OrderBy(fv => fv.Key)
                .Select(fv => fv.Value).ToList();        
        protected IReadOnlyList<IMultipleFieldsValidator<TNumberSpecification>> MultipleFieldsValidators { get; }        
        protected IStringParser<TNumberSpecification> StringParser { get; }

        protected NumberValidator(
            IEnumerable<IFieldValidator<TNumberSpecification>> fieldValidators,
            IEnumerable<IMultipleFieldsValidator<TNumberSpecification>> multipleFieldsValidators,
            IEnumerable<IFieldSpecification<TNumberSpecification>> fieldSpecifications,
            IStringParser<TNumberSpecification> stringParser = null)
        {
            fieldValidators = fieldValidators?.ToList() ?? new List<IFieldValidator<TNumberSpecification>>();
            MultipleFieldsValidators = multipleFieldsValidators?.ToList() ?? new List<IMultipleFieldsValidator<TNumberSpecification>>();
            FieldValidators = fieldSpecifications
                .OrderBy(fs => fs.Order)
                .ToDictionary(
                    fs => fs.Order,
                    fs => fieldValidators.SingleOrDefault(f => f.FieldSpecificationIdentifier.Id == fs.Identifier.Id)
                );
            StringParser = stringParser;
        }

        public virtual IValidationResult Validate(string[] input)
            => new ValidationResult(
                    OrderedFieldValidators.Select((fv, i) => fv.Validate(input[i]))
                    .Concat(EvaluateMultipleFieldsValidators(OrderedFieldValidators, input))
               );        

        public virtual IValidationResult Validate(string input)
            => Validate(StringParser != null ? StringParser.Parse(input) : new[] { input });

        private IEnumerable<IPartialValidationResult> EvaluateMultipleFieldsValidators(
            IReadOnlyList<IFieldValidator<TNumberSpecification>> orderedFieldValidators,
            string[] input)
        {
            var valuesPerFieldIdentifier = GetValuesPerFieldIdentifier(orderedFieldValidators, input);
            return new List<IPartialValidationResult>();
        }            

        private IEnumerable<KeyValuePair<Identifier, string>> GetValuesPerFieldIdentifier(
            IReadOnlyList<IFieldValidator<TNumberSpecification>> orderedFieldValidators, 
            string[] input)
            => orderedFieldValidators.Select((fv, i) => new KeyValuePair<Identifier, string>(key: fv.Identifier, value: input[i]));        
    }
}
