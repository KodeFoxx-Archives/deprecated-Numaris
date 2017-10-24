using System;
using System.Linq;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Implementations.KdgPersonNumber.Specification;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Parsing
{
    public sealed class StringToKdgNumberParser : StringParser<KdgNumberSpecification>
    {
        public override string[] Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return new[] { "0", "0" };

            var numbersOfTheInputString = input
                .Where(Char.IsDigit)
                .ToArray();

            return new[] {
                String.Join("", numbersOfTheInputString.Take(numbersOfTheInputString.Length - 2)),
                String.Join("", numbersOfTheInputString.Skip(numbersOfTheInputString.Length - 2))
            };
        }
    }
}
