using System.Linq.Expressions;
using System.Net;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Implementations;
using CommonLibrary.Repositories;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;

namespace WebClient.Implementations;

public class ObjectRepository : IObjectRepository<IObject>
{
    public ObjectRepository()
    {
    }

    public async Task<IEnumerable<IObject>> GetAllAsync()
    {
        return await WebClientSettings.GatewayServiceDevURL
            .AppendPathSegment("objects")
            .GetJsonAsync<IEnumerable<IIObject>>();
    }

    public Task<IEnumerable<IObject>> GetAllAsync(Expression<Func<IObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IObject> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IObject> GetAsync(Expression<Func<IObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(IObject? entity)
    {
        if (entity == null)
            await WebClientSettings.GatewayServiceDevURL
                .AppendPathSegment("objects").PostAsync();
    }
    

    public Task UpdateAsync(IObject entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IObject entity)
    {
        throw new NotImplementedException();
    }

    public Task SuspendAsync(IObject entity)
    {
        throw new NotImplementedException();
    }
}