using Vilas.Utils.Text.Validators;

namespace Vilas.Utils.Text.Tests.Validators
{
    public class CpfValidatorTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("123", false)]
        [InlineData("teste", false)]
        [InlineData("499.758.756-70", true)]
        [InlineData("53613665603", true)]
        public void When_CpfIsValid_ShouldReturnTrue(string cpf, bool valid)
        {
            //Act
            var result = CpfValidator.IsValid(cpf);

            //Assert
            Assert.Equal(valid, result);
        }
    }
}