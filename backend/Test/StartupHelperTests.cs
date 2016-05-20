
using Xunit;
using DockerTestProject;

namespace DockerTestProject.Test {
    public class StartupHelperTests {
        private const string POSTGRES_URL = "postgresql://postgres@localhost/docker-test-project";
        private const string POSTGRES_URL_WITH_PASSWORD = "postgresql://postgres:mypassword@localhost/docker-test-project";
        public class GetConnectionString : StartupHelperTests {

            [Fact]
            public void WhenGivenAPostgresURL_ItShouldReturnADotNetConnectionString() {
                var connString = StartupHelper.GetConnectionString(POSTGRES_URL);

                Assert.Equal(
                    "Server=localhost;Port=5432;Database=docker-test-project;User Id=postgres;Password=",
                    connString);
            }

            [Fact]
            public void WhenGivenAPostgresURLWithPassword_ItShouldReturnADotNetConnectionString() {
                var connString = StartupHelper.GetConnectionString(POSTGRES_URL_WITH_PASSWORD);

                Assert.Equal(
                    "Server=localhost;Port=5432;Database=docker-test-project;User Id=postgres;Password=mypassword",
                    connString);
            }
        }
    }
}
