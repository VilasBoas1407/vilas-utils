using Vilas.Utils.Text.Validators;

namespace Vilas.Utils.Text.Tests.Validators
{
    public sealed class PasswordValidatorTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("1234567", false)]
        [InlineData("password", false)]
        [InlineData("12345678", false)]
        [InlineData("abcdefgh", false)]
        [InlineData("ABCDEFGH", false)]
        [InlineData("Abcdefgh", false)]
        [InlineData("Abcdefg1", false)]
        [InlineData("Abcdefg!", false)]
        [InlineData("A1!b2@c3#", true)]
        [InlineData("Str0ngP@ssw0rd!", true)]
        [InlineData("Qwerty123!", false)]
        [InlineData("Test@1234", false)]
        [InlineData("S3cur3P@ss", true)]
        public void When_PasswordIsChecked_ShouldReturnExpectedResult(string password, bool expected)
        {
            // Act
            var result = PasswordValidator.IsValid(password);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
