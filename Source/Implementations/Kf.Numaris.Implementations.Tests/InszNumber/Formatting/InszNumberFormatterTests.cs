using Kf.Numaris.Implementations.InszNumber.Formatting;
using Kf.Numaris.Implementations.InszNumber.Parsing;
using Xunit;

namespace Kf.Numaris.Implementations.Tests.InszNumber.Formatting
{
    public class InszNumberFormatterTests
    {
        [Theory, 
         InlineData(
            "When given as on e-id card", 
            "85.10.11-427.31", "85.10.11-427.31"),
         InlineData(
             "When given as one big number",
             "85101142731", "85.10.11-427.31"),
         InlineData(
             "When given with spaces",
             "851011 427 31", "85.10.11-427.31"),
         InlineData(
             "When given with spaces",
             "85 10 11 42 7 3  1", "85.10.11-427.31"),
         InlineData(
             "When given totally scrambled",
             "8--5. 1 0.  .  @11-4#27 - /.31", "85.10.11-427.31"),
        ]
        public void Returns_correct_formatting_given(string scenario, string input, string expected)
        {
            var sut = CreateInszNumberFormatter();
            var actual = sut.Format(input);
            Assert.Equal(expected, actual);
        }

        private InszNumberFormatter CreateInszNumberFormatter()
            => new InszNumberFormatter(
                    fieldFormatters: InszNumberTestData.FieldFormatters,
                    fieldSpecifications: InszNumberTestData.FieldSpecifications,
                    stringParser: new StringToInszNumberParser()
               );
    }
}
