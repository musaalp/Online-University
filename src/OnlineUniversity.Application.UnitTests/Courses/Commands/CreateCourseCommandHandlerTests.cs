using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Application.Courses.Commands.CreateCourse;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Courses;
using System.Threading;

namespace OnlineUniversity.Application.UnitTests.Courses.Commands
{
    [TestClass]
    public class CreateCourseCommandHandlerTests
    {
        [TestMethod]
        public void Handle_WithValidRequest_ShouldDispatchEvents()
        {
            // Arrange            
            var mockRepository = new Mock<ICourseRepository>();
            var mockDomainEventsDispatcher = new Mock<IDomainEventsDispatcher>();

            var sut = new CreateCourseCommandHandler(mockRepository.Object, mockDomainEventsDispatcher.Object);

            //Act
            var result = sut.Handle(new CreateCourseCommand(), CancellationToken.None);

            //Assert            
            mockDomainEventsDispatcher.Verify(d => d.DispatchEventsAsync(), Times.Once);
        }
    }
}
