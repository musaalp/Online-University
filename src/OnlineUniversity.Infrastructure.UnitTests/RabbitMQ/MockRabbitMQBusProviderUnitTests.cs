using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Domain.Students;
using OnlineUniversity.Infrastructure.RabbitMQ;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.UnitTests.RabbitMQ
{
    [TestClass]
    public class MockRabbitMQBusProviderUnitTests
    {
        [TestMethod]
        public async Task PublishAsync_WithStudentSignedUpEvent_ShouldEnqueueEvent()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();

            var sut = new MockRabbitMQBusProvider(mockMediator.Object);

            var studentSignedUpEventToSend = new StudentSignedUpEvent(It.IsAny<Guid>(), It.IsAny<string>());

            //Act
            await sut.PublishAsync(studentSignedUpEventToSend);

            //Assert
            var studentSignedUpEventReceived = sut._mockQueue.Dequeue() as StudentSignedUpEvent;

            Assert.AreSame(studentSignedUpEventToSend, studentSignedUpEventReceived);
        }

        [TestMethod]
        public async Task SubscribeAsync_WithStudentSignedUpEvent_ShouldDequeueEventAndConvert()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();

            var sut = new MockRabbitMQBusProvider(mockMediator.Object);

            var studentSignedUpEventToSend = new StudentSignedUpEvent(It.IsAny<Guid>(), It.IsAny<string>());

            //Act
            await sut.PublishAsync(studentSignedUpEventToSend);
            await sut.SubscribeAsync();

            //Assert                                    
            mockMediator.Verify(m => m.Publish(It.IsAny<StudentSignUpProcessedEvent>(), CancellationToken.None), Times.Once);
        }
    }
}
