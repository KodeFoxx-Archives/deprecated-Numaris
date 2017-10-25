using System;
using System.Linq;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Parsing
{
    public sealed class StringToKdgPersonNumberParser : StringParser<KdgPersonNumberSpecification>
    {
        public override string[] Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return new[] { "0", "0" };

            var numbersOfTheInputString = input
                .Where(Char.IsLetterOrDigit)
                .ToArray();

            return new[] {
                String.Join("", numbersOfTheInputString.Take(numbersOfTheInputString.Length - 2)),
                String.Join("", numbersOfTheInputString.Skip(numbersOfTheInputString.Length - 2))
            };
        }
    }
}
