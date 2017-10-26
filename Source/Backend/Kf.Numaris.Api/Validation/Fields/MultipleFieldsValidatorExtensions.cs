using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Fields
{
    public static class MultipleFieldsValidatorExtensions        
    {
        public static string GetValueForField<TFieldSpecification, TNumberSpecification>(this IEnumerable<KeyValuePair<Identifier, string>> input)
            where TFieldSpecification : IFieldSpecification<TNumberSpecification>
            where TNumberSpecification : INumberSpecification
            => input.Where(kv => kv.Key.Id.Equals(Identifier.For<TFieldSpecification>().Id))
                .Select(kv => kv.Value)
                .SingleOrDefault();
    }
}
