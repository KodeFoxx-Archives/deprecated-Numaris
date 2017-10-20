using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Parsing;

namespace Kf.Numaris.Api.Implementations.KdgStudentNumber
{
    public sealed class KdgStudentNumberParser : NumberParser<KdgStudentNumberSpecification>
    {
        public override string[] Parse(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                throw new NumberParserException(new ArgumentNullException(nameof(input)));

            if (CanParseWhenInputContainsHyphen(input, out var parsedResult))
                return parsedResult;

            if (CanParseWhenInputIsAlphanumeric(input, out parsedResult))
                return parsedResult;

            throw new NumberParserException(_baseExceptionString);
        }

        private bool CanParseWhenInputContainsHyphen(string input, out string[] parsedResult)
        {
            parsedResult = null;

            if (!input.Contains("-"))
                return false;

            if (input.Count(c => c == '-') > 1)
                throw new NumberParserException($"{_baseExceptionString} The input can only contain 0 or 1 hyphen.");

            var splittedInput = input.Split(new[] { "-" }, StringSplitOptions.None);

            if (String.IsNullOrEmpty(splittedInput[0]) || String.IsNullOrWhiteSpace(splittedInput[1]))
                throw new NumberParserException($"{_baseExceptionString} The input needs at least one character before and after the hyphen.");

            parsedResult = splittedInput;
            return true;
        }

        private bool CanParseWhenInputIsAlphanumeric(string input, out string[] parsedResult)
        {
            parsedResult = null;

            if (input.Length < 3)
                throw new NumberParserException($"{_baseExceptionString} The input needs to have at least three characters.");

            parsedResult = new List<string> {
                input.Substring(0, input.Length-2),
                String.Join(String.Empty, input.Skip(input.Length-2))
            }.ToArray();
            return true;
        }
    }
}
