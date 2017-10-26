namespace Kf.Numaris.Implementations.InszNumber.Validation
{
    public enum ValidationErrorMessages
    {
        CanNotBeBlank,
        CanOnlyConsistOfDigitsInRangeFrom0To9,
        CanNotBeLargerThanXCharacters,
        CheckDigitsDoNotMatch
    }

    public enum ValidationWarningMessages
    {
        DoesNotContainPaddingZeroes
    }
}
