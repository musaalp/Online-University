using MediatR;
using OnlineUniversity.Application.Cache;
using System.Collections.Generic;

namespace OnlineUniversity.Application.Statistics.Queries
{
    public class GetStatisticsQuery : CacheableQuery, IRequest<IEnumerable<StatisticDto>>
    {
        public GetStatisticsQuery()
        {
            CacheKey = CacheKeys.StatisticsCacheKey;
            CacheTime = 10;
        }
    }
}
