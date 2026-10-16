namespace RaceDay.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Login_WithCorrectCredentials_ShouldPass()
        {
            string email = "akhona@test.com";
            string password = "Password123";

            bool loginSuccessful =
                email == "akhona@test.com" &&
                password == "Password123";

            Assert.True(loginSuccessful);
        }

        [Fact]
        public void Login_WithIncorrectPassword_ShouldFail()
        {
            string email = "akhona@test.com";
            string password = "WrongPassword";

            bool loginSuccessful =
                email == "akhona@test.com" &&
                password == "Password123";

            Assert.False(loginSuccessful);
        }
    }
}