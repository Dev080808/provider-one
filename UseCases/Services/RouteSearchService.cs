using ProviderOne.DataAccess.Interfaces;
using ProviderOne.UseCases.Mapping;

using SystemAggregator.Clients.ProviderOne.Constatnts;
using SystemAggregator.Clients.ProviderOne.Models;
using SystemAggregator.Core.Extensions;
using SystemAggregator.Services.SearchService;

namespace ProviderOne.UseCases.Services
{
    public class RouteSearchService :
        SearchService<ProviderOneSearchRequest, ProviderOneSearchResponse>
    {
        private readonly IRouteRepository _repo;

        public RouteSearchService(IRouteRepository repo)
        {
            _repo = repo;
        }

        public override string SearchCode => SearchCodes.Route;

        protected override async Task<ProviderOneSearchResponse> InvokeSearch(ProviderOneSearchRequest param)
        {
            var filter = param.ToFilter();
            var routes = await _repo.Search(filter);

            return new ProviderOneSearchResponse()
            {
                Routes = routes.IsEmpty()
                    ? Array.Empty<ProviderOneRoute>()
                    : routes.Select(SearchMapping.ToProviderOnFormat).ToArray()
            };
        }
    }
}
