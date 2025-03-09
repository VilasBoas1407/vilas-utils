namespace Vilas.Utils.Text.Tests
{
    public class CpfUtilsTest
    {
        [Theory]
        [InlineData(null,false)]
        [InlineData("123",false)]
        [InlineData("teste",false)]
        [InlineData("499.758.756-70",true)]
        [InlineData("53613665603", true)]
        public void When_CpfIsValid_ShouldReturnTrue(string cpf, bool valid)
        {
            //Act
            var result = Cpf.Validate(cpf);

            //Assert
            Assert.Equal(valid, result);
        }
    }
}