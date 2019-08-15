using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Application.Courses.Commands.SignUpCourse;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Students;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.UnitTests.Courses.Commands
{
    [TestClass]
    public class StudentSignUpProcessedEventHandlerTests
    {
        [TestMethod]
        public async Task Handle_WithValidEvent_ShouldCheckCourseCapacity()
        {
            // Arrange            
            var mockCourseSignUpPolicy = new Mock<ICourseSignUpPolicy>();

            var sut = new StudentSignUpProcessedEventHandler(mockCourseSignUpPolicy.Object);

            var courseId = It.IsAny<Guid>();
            var email = It.IsAny<string>();

            //Act
            await sut.Handle(new StudentSignUpProcessedEvent
            (
                courseId,
                email
            ),
            CancellationToken.None);

            //Assert                        
            mockCourseSignUpPolicy.Verify(m => m.CheckCapacity(courseId));
        }
    }
}
