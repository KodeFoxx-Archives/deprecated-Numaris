using System;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Implementations.KdgPersonNumber.Specification;
using Kf.Numaris.Implementations.KdgPersonNumber.Specification.Fields;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Formatting
{
    public sealed class PersonNumberFieldFormatter : FieldFormatter<PersonNumberFieldSpecification, KdgNumberSpecification>
    {
        private readonly int _maxLength = 7;
        private char _paddingCharacter = '0';

        public override string Format(string input)
        {
            if (input.Length >= _maxLength)
                return input;

            return $"{new String(_paddingCharacter, _maxLength - input.Length)}{input}";
        }
    }
}
