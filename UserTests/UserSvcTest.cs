using Microsoft.Extensions.Logging;
using Moq;
using User.Domain;
using User.Interfaces;
using User.Services;

namespace UserTests
{
    public class UserSvcTest
    {
        private Mock<ILogger<IUserSvc>> mockLogger;
        private Mock<IProductSvcAdapter> mockProductSvcAdapter;
        private UserSvc userSvc;

        //Initialize
        //[Test]
        public void Init()
        {
            mockLogger = new Mock<ILogger<IUserSvc>>();

            userSvc = new UserSvc(mockLogger.Object, mockProductSvcAdapter.Object);
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