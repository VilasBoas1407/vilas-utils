namespace Vilas.Utils.Text.Tests.Result
{
    public class ResultTests
    {
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var result = new Result<string>();

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Errors);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void AddError_ShouldAddErrorToList()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.AddError("Test error");

            // Assert
            Assert.Single(result.Errors);
            Assert.Contains("Test error", result.Errors);
        }

        [Fact]
        public void ErrorMessageString_ShouldReturnConcatenatedErrors()
        {
            // Arrange
            var result = new Result<string>();
            result.AddError("Error 1");
            result.AddError("Error 2");

            // Act
            var errorMessage = result.ErrorMessageString;

            // Assert
            Assert.Equal("Error 1;Error 2", errorMessage);
        }

        [Fact]
        public void Ok_ShouldSetDataAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.Ok("Success data");

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Success data", result.Data);
        }

        [Fact]
        public void Created_ShouldSetDataAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.Created("Created data");

            // Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Created data", result.Data);
        }

        [Fact]
        public void Conflict_ShouldSetErrorAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.Conflict("Conflict error");

            // Assert
            Assert.Equal(409, result.StatusCode);
            Assert.Contains("Conflict error", result.Errors);
        }

        [Fact]
        public void NotFound_ShouldSetErrorAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.NotFound("Not found error");

            // Assert
            Assert.Equal(404, result.StatusCode);
            Assert.Contains("Not found error", result.Errors);
        }

        [Fact]
        public void BadRequest_ShouldSetErrorAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.BadRequest("Bad request error");

            // Assert
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Bad request error", result.Errors);
        }

        [Fact]
        public void InternalServerError_ShouldSetErrorAndStatusCode()
        {
            // Arrange
            var result = new Result<string>();

            // Act
            result.InternalServerError("Internal server error");

            // Assert
            Assert.Equal(500, result.StatusCode);
            Assert.Contains("Internal server error", result.Errors);
        }

        [Fact]
        public void FromStatusCode_ShouldSetStatusCodeAndErrors()
        {
            // Arrange
            var result = new Result<string>();
            var errors = new List<string> { "Error 1", "Error 2" };

            // Act
            result.FromStatusCode(400, errors);

            // Assert
            Assert.Equal(400, result.StatusCode);
            Assert.Equal(errors, result.Errors);
        }
    }
}
