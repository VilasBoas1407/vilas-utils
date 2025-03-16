using Vilas.Utils.Text.Validators;

namespace Vilas.Utils.Text.Tests.Validators
{
    public sealed class EmailValidatorTest
    {
        [Theory]
        [InlineData("lucas@email.com", true)]
        [InlineData("lucas.vilas@email.com.br", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("lucas.vilas.com.br", false)]
        [InlineData("123", false)]
        [InlineData("lucas12!@mail.com.br", true)]
        public void WhenEmailIsValid_Should_ReturnTrue(string email, bool expected)
        {
            //Act
            var result = EmailValidator.IsValid(email);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
