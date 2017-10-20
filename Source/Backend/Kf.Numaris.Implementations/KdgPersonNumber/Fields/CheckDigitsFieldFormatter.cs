using Kf.Numaris.Api.Formatting.Fields;
using System;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Fields
{
    public sealed class CheckDigitsFieldFormatter : FieldFormatter<CheckDigitsFieldSpecification, KdgNumberSpecification>
    {
        private readonly int _maxLength = 2;
        private char _paddingCharacter = '0';

        public override string Format(string input)
        {
            if (input.Length == _maxLength)
                return input;

            if (input.Length > _maxLength)
                return input.Substring(0, _maxLength);

            return $"{new String(_paddingCharacter, _maxLength - input.Length)}{input}";
        }
    }
}
