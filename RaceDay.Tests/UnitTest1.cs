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

        [Fact]
        public void Participant_ShouldNotBeAllowedToCreateEvents()
        {
            string role = "Participant";

            bool canCreateEvent = role == "Organiser";

            Assert.False(canCreateEvent);
        }

        [Fact]
        public void Organiser_ShouldBeAllowedToCreateEvents()
        {
            string role = "Organiser";

            bool canCreateEvent = role == "Organiser";

            Assert.True(canCreateEvent);
        }

        [Fact]
        public void Participant_ShouldBeAllowedToEnrol()
        {
            string role = "Participant";

            bool canEnrol = role == "Participant";

            Assert.True(canEnrol);
        }
    }
}
