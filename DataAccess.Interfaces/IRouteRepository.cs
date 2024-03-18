using ProviderOne.DataAccess.Interfaces.Models;
using ProviderOne.Entities.Models;

namespace ProviderOne.DataAccess.Interfaces
{
    public interface IRouteRepository
    {
        Task<List<Route>> Search(RouteSearchFilter filter);
    }
}
