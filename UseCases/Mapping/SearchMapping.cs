using ProviderOne.DataAccess.Interfaces.Models;
using ProviderOne.Entities.Models;

using SystemAggregator.Clients.ProviderOne.Models;

namespace ProviderOne.UseCases.Mapping
{
    public static class SearchMapping
    {
        public static RouteSearchFilter ToFilter(this ProviderOneSearchRequest request)
        {
            return new RouteSearchFilter
            {
                Origin = request.From,
                Destination = request.To,
                OriginDate = request.DateFrom,
                DestinationDate = request.DateTo,
                MaxPrice = request.MaxPrice,
            };
        }

        public static ProviderOneRoute ToProviderOnFormat(this Route route)
        {
            return new ProviderOneRoute
            {
                Id = route.Id,
                From = route.Origin,
                To = route.Destination,
                DateFrom = route.OriginDateTime,
                DateTo = route.DestinationDateTime,
                Price = route.Price,
                TimeLimit = route.TimeLimit,
            };
        }
    }
}
