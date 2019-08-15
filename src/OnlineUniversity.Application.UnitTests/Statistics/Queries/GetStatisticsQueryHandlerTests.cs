using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineUniversity.Application.Cache;
using OnlineUniversity.Application.Contracts.Cache;
using OnlineUniversity.Application.Statistics.Queries;
using OnlineUniversity.Domain.Courses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.UnitTests.Courses.Queries
{
    [TestClass]
    public class GetStatisticsQueryHandlerTests
    {
        [TestMethod]
        public async Task Handle_WithValidRequest_ShouldUseCacheProvider()
        {
            // Arrange            
            var mockRepository = new Mock<ICourseRepository>();
            var mockCacheProvider = new Mock<ICacheProvider>();
            var mockCacheOptions = new Mock<IOptions<CacheOptions>>();

            var cacheManager = new CacheManager(mockCacheProvider.Object, mockCacheOptions.Object);

            var sut = new GetStatisticsQueryHandler(mockRepository.Object, cacheManager, mockCacheOptions.Object);

            //Act
            var result = await sut.Handle(new GetStatisticsQuery(), CancellationToken.None);

            //Assert            
            mockCacheProvider.Verify(m => m.GetAsync<IEnumerable<StatisticDto>>(It.IsAny<string>()), Times.Once);
            mockCacheProvider.Verify(m => m.SetAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }
    }
}
