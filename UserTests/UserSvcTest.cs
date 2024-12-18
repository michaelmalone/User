using Microsoft.Extensions.Logging;
using Moq;
using User.Domain;
using User.Services;

namespace UserTests
{
    public class UserSvcTest
    {
        private Mock<ILogger> mockLogger;
        private UserSvc userSvc;

        //Initialize
        //[Test]
        public void Init()
        {
            mockLogger = new Mock<ILogger>();
            userSvc = new UserSvc(mockLogger.Object);
        }

        [Fact]
        public void CanCreate()
        {
            //Arrange
            Init();
            var AppUser = new AppUser
            {
                Id = 1,
                Name = "Test",
                Address = "123 address",
                Email = "test@example.com"
            };
            //Act 
            var result = userSvc.Create(AppUser);
            //Assert
           Assert.NotNull(result);
        }
    }
}