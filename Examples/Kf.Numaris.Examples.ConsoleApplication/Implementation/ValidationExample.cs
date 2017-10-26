using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Validation.Numbers;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Presentation.ConsoleApplicationExample;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation
{
    class ValidationExample : IExample
    {
        private readonly INumberValidator<KdgPersonNumberSpecification> _numberValidator;
        private readonly List<string> _numbers = new List<string>
        {
            "003331140", "3331140", "140", "33311.40", "  00 3 3 3 11  40",
            "003331139", "3331150", "101", "33311.39", "  00 3 3 3 11  39"
        };

        public ValidationExample(INumberValidator<KdgPersonNumberSpecification> numberValidator)
            => _numberValidator = numberValidator;

        public string Notes => "The validator uses the parser internally, to first parse a string in to an array of strings.";

        public void Run()
        {
            _numbers.ToList().ForEach(number =>
            {
                var result = _numberValidator.Validate(number);
                Console.WriteLine($"- '{number}' is '{(result.IsValid ? "valid" : "not valid")}'.");
                
                result.PartialResults.Where(pr => pr.HasMessage).ToList().ForEach(pr =>
                {
                    Console.WriteLine($"  - {pr.Message} on field '{pr.Identifier.Name}'.");
                });
            });
        }
    }
}
