using MediatR;
using Microsoft.Extensions.Options;
using OnlineUniversity.Application.Contracts.Cache;
using OnlineUniversity.Application.Extensions;
using OnlineUniversity.Domain.Courses;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Statistics.Queries
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, IEnumerable<StatisticDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICacheManager _cacheManager;
        private readonly CacheOptions _cacheOptions;

        public GetStatisticsQueryHandler(ICourseRepository courseRepository, ICacheManager cacheManager, IOptions<CacheOptions> cacheOptions)
        {
            _courseRepository = courseRepository;
            _cacheManager = cacheManager;
            _cacheOptions = cacheOptions.Value;
        }

        public async Task<IEnumerable<StatisticDto>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            return await _cacheManager.GetOrSetAsync(
                request.CacheKey,
                request.CacheTime ?? _cacheOptions.DefaultCacheTime,
                () => CalculateStatistics());
        }

        private async Task<List<StatisticDto>> CalculateStatistics()
        {
            var statistics = new List<StatisticDto>();

            var courses = await _courseRepository.GetAllAsync();

            var tasks = courses.ToList().Select(async (course) =>
            {
                await Task.Run(() =>
                {
                    statistics.Add(new StatisticDto
                    {
                        CourseName = course.Name,
                        MinimumAge = course.Students.Max(s => s.DateOfBirth).ToAge(),
                        MaximumAge = course.Students.Min(s => s.DateOfBirth).ToAge(),
                        AverageAge = course.Students.Select(s => s.DateOfBirth.Year).Average().ToAge()
                    });
                });
            });

            await Task.WhenAll(tasks);

            return statistics;
        }
    }
}
