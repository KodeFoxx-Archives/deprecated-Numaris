using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Parsing.Parsers
{
    public abstract class StringParser<TNumberSpecification> : IStringParser<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        protected readonly IReadOnlyList<IFieldSpecification<TNumberSpecification>> _fieldSpecifications;

        protected StringParser(IEnumerable<IFieldSpecification<TNumberSpecification>> fieldSpecifications)
            => _fieldSpecifications = fieldSpecifications?.ToList() ?? new List<IFieldSpecification<TNumberSpecification>>();        

        public abstract string[] Parse(string input);
    }
}
