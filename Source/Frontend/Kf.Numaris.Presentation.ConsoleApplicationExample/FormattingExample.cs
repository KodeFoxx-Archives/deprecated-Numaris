using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;

namespace Kf.Numaris.Presentation.ConsoleApplicationExample
{
    class FormattingExample : IExample
    {
        private readonly INumberFormatter<KdgNumberSpecification> _numberFormatter;
        private readonly List<string[]> _numbers = new List<string[]>
        {
            new []{ "33311", "4" },
            new []{ "33311", "40" },
            new []{ "0033311", "40" }
        };

        public FormattingExample(INumberFormatter<KdgNumberSpecification> numberFormatter)
            => _numberFormatter = numberFormatter;        

        public void Run()
        {
            _numbers.ToList().ForEach(number =>
            {
                Console.WriteLine($"- {String.Join(" and ", number.Select(n => $"'{n}'"))}' formatted becomes '{_numberFormatter.Format(number)}'.");
            });
        }
    }
}
