using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications.Concrete
{
    public class KdgStudentNumberSpecifications
    {
        [Theory,
         InlineData("003331140", "0033311-40"),
         InlineData("3331140", "0033311-40"),
         InlineData("33311-40", "0033311-40"),
         InlineData("0033311-40", "0033311-40")]
        public void Can_parse_a_valid_student_numbert(string input, string expected)
        {
            Assert.Equal(input, expected);
        }

        [Fact]
        public void Returns_true_when_given_a_valid_student_number()
        {
            var studentNumber = "003331140";
        }
    }
}
