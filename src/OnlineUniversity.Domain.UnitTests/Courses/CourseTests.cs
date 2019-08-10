using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Entities;
using OnlineUniversity.Domain.Students;
using System;
using System.Linq;

namespace OnlineUniversity.Domain.UnitTests.Courses
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_WithValidContsructor_ShouldRaiseCourseCreatedEvent()
        {
            //Arrange

            //Act
            var sut = new Course(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>());

            //Assert
            Assert.IsInstanceOfType(sut.DomainEvents.First(), typeof(CourseCreatedEvent));
        }

        [TestMethod]
        public void Course_WithValidContsructor_ShouldRaiseStudentSignedUpEvent()
        {
            //Arrange
            var sut = new Course(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>());
            sut.ClearDomainEvents();

            var student = new Student(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>());

            //Act
            sut.SignUpStudent(student);

            //Assert
            Assert.IsInstanceOfType(sut.DomainEvents.First(), typeof(StudentSignedUpEvent));
        }
    }
}
