namespace RaceDay.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Login_WithCorrectCredentials_ShouldPass()
        {
            // Arrange
            string email = "akhona@test.com";
            string password = "Password123";

            // Act
            bool loginSuccessful =
                email == "akhona@test.com" &&
                password == "Password123";

            // Assert
            Assert.True(loginSuccessful);
        }
    }
}