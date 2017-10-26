using System;
using System.Linq;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Implementations.InszNumber.Specification;

namespace Kf.Numaris.Implementations.InszNumber.Parsing
{
    public sealed class StringToInszNumberParser : StringParser<InszNumberSpecification>
    {
        public override string[] Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return new[] { "0", "0", "0", "0", "0" };

            var numbersOfTheInputString = input
                .Where(Char.IsLetterOrDigit)
                .ToArray();
            var numbersOfTheInputStringAsFlatString = String.Join("", numbersOfTheInputString);

            return new[] {
                numbersOfTheInputStringAsFlatString.Substring(0, 2),
                numbersOfTheInputStringAsFlatString.Substring(2, 2),
                numbersOfTheInputStringAsFlatString.Substring(4, 2),
                numbersOfTheInputStringAsFlatString.Substring(6, 3),
                numbersOfTheInputStringAsFlatString.Substring(9, 2)
            };
        }
    }
}
