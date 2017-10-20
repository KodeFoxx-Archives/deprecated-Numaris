using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Kf.Numaris.Api
{
    public interface INumber<TNumber>
        where TNumber : class, INumber<TNumber>
    {
    }

    public abstract class Number<TNumber> : INumber<TNumber>
        where TNumber : class, INumber<TNumber>
    {
        protected readonly INumberParser<TNumber> _numberParser;

        protected Number(INumberParser<TNumber> numberParser)
            => _numberParser = numberParser ?? throw new ArgumentNullException(nameof(numberParser));
    }

    public sealed class KdgStudentNumber : Number<KdgStudentNumber>
    {
        public KdgStudentNumber(INumberParser<KdgStudentNumber> numberParser)
            : base(numberParser)
        {
        }
    }

    public interface INumberParser<TNumber>
        where TNumber : class, INumber<TNumber>
    {
        string[] Parse(string input);
    }

    public abstract class NumberParser<TNumber> : INumberParser<TNumber>
        where TNumber : class, INumber<TNumber>
    {
        protected readonly string _baseExceptionString = $"Unable to parse given input to {typeof(TNumber).Name}.";

        public virtual string[] Parse(string input) =>
            throw new NotImplementedException($"{typeof(TNumber).Name} needs to have a parser implemented.");
    }

    public class NumberParserException : Exception
    {
        public NumberParserException(Exception exception)
            : base(exception.Message, exception) { }
        public NumberParserException(string message)
            : base(message) { }
        public NumberParserException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public sealed class KdgStudentNumberParser : NumberParser<KdgStudentNumber>
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
