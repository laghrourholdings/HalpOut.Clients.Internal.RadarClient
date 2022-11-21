using System.Linq.Expressions;
using CommonLibrary.Core;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;

namespace WebClient.Implementations;

public class ObjectRepository : IRepository<IIObject>
{
    public ObjectRepository()
    {
    }

    public async Task<IEnumerable<IIObject>?> GetAllAsync()
    {
        return await ServicesSettings.GatewayServiceDevURL
            .AppendPathSegment("objects")
            .GetJsonAsync<IEnumerable<IIObject>>();
    }

    public Task<IEnumerable<IIObject>?> GetAllAsync(Expression<Func<IIObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IIObject?> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IIObject?> GetAsync(Expression<Func<IIObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(
        IIObject entity)
    {
        await ServicesSettings.GatewayServiceDevURL
            .AppendPathSegment("objects")
            .PostAsync();
    }

    public Task RangeAsync(IEnumerable<IIObject> entity)
    {
        throw new NotImplementedException();
    }


    public Task UpdateAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrCreateAsync(
        IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrCreateAsync(
        IObject entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task SuspendAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }
}