using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Presentation.ConsoleApplicationExample;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation
{
    class FormattingExample : IExample
    {
        private readonly INumberFormatter<KdgPersonNumberSpecification> _numberFormatter;
        private readonly List<string> _numbers = new List<string>
        {
            "003331140", "3331140", "140", "33311.40", "  00 3 3 3 11  40"
        };

        public FormattingExample(INumberFormatter<KdgPersonNumberSpecification> numberFormatter)
            => _numberFormatter = numberFormatter;

        public string Notes => "The formatter uses the parser internally, to first parse a string in to an array of strings.";

        public void Run()
        {
            _numbers.ToList().ForEach(number =>
            {
                Console.WriteLine($"- '{number}' formatted becomes '{_numberFormatter.Format(number)}'.");
            });
        }
    }
}
