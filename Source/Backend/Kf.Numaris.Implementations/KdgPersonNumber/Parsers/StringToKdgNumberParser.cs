using System.Collections.Generic;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Parsers
{
    public sealed class StringToKdgNumberParser : StringParser<KdgNumberSpecification>
    {
        public StringToKdgNumberParser(IEnumerable<IFieldSpecification<KdgNumberSpecification>> fieldSpecifications) 
            : base(fieldSpecifications)
        {
        }

        public override string[] Parse(string input)
        {
            return null;
        }
    }
}
