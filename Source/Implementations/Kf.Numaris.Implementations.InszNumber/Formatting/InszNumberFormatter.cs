using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Implementations.InszNumber.Specification;

namespace Kf.Numaris.Implementations.InszNumber.Formatting
{
    public sealed class InszNumberFormatter : NumberFormatter<InszNumberSpecification>
    {
        public InszNumberFormatter(
            IEnumerable<IFieldFormatter<InszNumberSpecification>> fieldFormatters, 
            IEnumerable<IFieldSpecification<InszNumberSpecification>> fieldSpecifications, 
            IStringParser<InszNumberSpecification> stringParser = null) 
            : base(fieldFormatters, fieldSpecifications, stringParser)
        { }

        private readonly string _template = "{0}.{1}.{2}-{3}.{4}";

        public override string Format(string[] input)
        {
            var formatted = _template;

            foreach (var fieldFormatter in OrderedFieldFormatters.Select((ff, i) => (Formatter: ff, Index: i)))            
                formatted = formatted
                    .Replace($"{{{fieldFormatter.Index}}}", fieldFormatter.Formatter.Format(input[fieldFormatter.Index]));            

            return formatted;
        }
    }

    public abstract class NumberWithPaddedZeroesInFrontFormatter<TFieldSpecification> 
        : FieldFormatter<TFieldSpecification, InszNumberSpecification>
        where TFieldSpecification: IFieldSpecification<InszNumberSpecification>
    {
        protected int MaxLength { get; }
        protected char PaddingCharacter { get; }

        protected NumberWithPaddedZeroesInFrontFormatter(int maxLength = 2, char paddingCharacter = '0')
        {
            MaxLength = maxLength;
            PaddingCharacter = paddingCharacter;
        }

        public override string Format(string input)
        {
            if (input.Length >= MaxLength)
                return input;

            return $"{new String(PaddingCharacter, MaxLength - input.Length)}{input}";
        }
    }

    public sealed class DateOfBirthYearFormatter 
        : NumberWithPaddedZeroesInFrontFormatter<DateOfBirthYearFieldSpecification>
    {        
    }

    public sealed class DateOfBirthMonthFormatter
        : NumberWithPaddedZeroesInFrontFormatter<DateOfBirthMonthFieldSpecification>
    {
    }

    public sealed class DateOfBirthDayFormatter
        : NumberWithPaddedZeroesInFrontFormatter<DateOfBirthDayFieldSpecification>
    {
    }

    public sealed class DayCounterFormatter
        : NumberWithPaddedZeroesInFrontFormatter<DayCounterFieldSpecification>
    {
        public DayCounterFormatter() : base(maxLength: 3) { }
    }

    public sealed class CheckDigitsFormatter
        : NumberWithPaddedZeroesInFrontFormatter<CheckDigitsFieldSpecification>
    {
    }
}
