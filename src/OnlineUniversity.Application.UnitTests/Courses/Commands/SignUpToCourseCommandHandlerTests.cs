using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Application.Courses.Commands.SignUpCourse;
using OnlineUniversity.Application.Exceptions;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Students;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.UnitTests.Courses.Commands
{
    [TestClass]
    public class SignUpToCourseCommandHandlerTests
    {
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task Handle_WithInValidCourseId_ShouldDispatchEvents()
        {
            // Arrange            
            var mockCourseRepository = new Mock<ICourseRepository>();
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockDomainEventsDispatcher = new Mock<IDomainEventsDispatcher>();
            var inValidCourseId = Guid.NewGuid();

            var sut = new SignUpToCourseCommandHandler(mockCourseRepository.Object, mockStudentRepository.Object, mockDomainEventsDispatcher.Object);

            //Act
            var result = await sut.Handle(new SignUpToCourseCommand
            {
                CourseId = inValidCourseId
            },
            CancellationToken.None);

            //Assert                        
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task Handle_WithInValidStudenEmail_ShouldDispatchEvents()
        {
            // Arrange            
            var mockCourseRepository = new Mock<ICourseRepository>();
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockDomainEventsDispatcher = new Mock<IDomainEventsDispatcher>();
            var inValidStudentEmail = It.IsAny<string>();

            var sut = new SignUpToCourseCommandHandler(mockCourseRepository.Object, mockStudentRepository.Object, mockDomainEventsDispatcher.Object);

            //Act
            var result = await sut.Handle(new SignUpToCourseCommand
            {
                StudentEmail = inValidStudentEmail
            },
            CancellationToken.None);

            //Assert                        
        }
    }
}
