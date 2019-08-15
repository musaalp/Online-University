using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Application.Courses.Queries;
using OnlineUniversity.Domain.Courses;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.UnitTests.Courses.Queries
{
    [TestClass]
    public class GetCourseQueryHandlerTests
    {
        [TestMethod]
        public async Task Handle_WithValidRequest_ShouldReturnCourse()
        {
            // Arrange            
            var mockRepository = new Mock<ICourseRepository>();
            var course = new Course(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>());

            mockRepository.Setup(m => m.GetByIdAsync(course.Id)).Returns(Task.FromResult(course));

            var sut = new GetCourseQueryHandler(mockRepository.Object);

            //Act
            var result = await sut.Handle(new GetCourseQuery { Id = course.Id }, CancellationToken.None);

            //Assert            
            mockRepository.Verify(m => m.GetByIdAsync(course.Id), Times.Once);
            Assert.AreEqual(course.Id.ToString(), result.Id);
        }
    }
}
