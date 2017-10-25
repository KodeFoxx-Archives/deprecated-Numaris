using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Presentation.ConsoleApplicationExample;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation
{
    class ParsingExample : IExample
    {
        private readonly IStringParser<KdgPersonNumberSpecification> _stringParser;
        private readonly List<string> _numbers = new List<string>
        {
            "003331140", "3331140", "140", "33311.40", "  00 3 3 3 11  40"
        };

        public ParsingExample(IStringParser<KdgPersonNumberSpecification> stringParser)
            => _stringParser = stringParser;

        public string Notes => "The parser demonstrated here is used internally in the API, e.g. in the formatters.";

        public void Run()
        {
            _numbers.ToList().ForEach(number =>
            {
                Console.WriteLine($"- '{number}' parsed becomes:");
                _stringParser.Parse(number)
                    .ToList()
                    .ForEach(parsedPart => Console.WriteLine($" - '{parsedPart}"));
            });
        }
    }
}
