using System.Linq.Expressions;
using CommonLibrary.Core;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;

namespace WebClient.Implementations;

public class ObjectRepository : IRepository<IObject>
{
    public ObjectRepository()
    {
    }

    public async Task<IEnumerable<IObject>> GetAllAsync()
    {
        return await ServicesSettings.GatewayServiceDevURL
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

    public Task CreateAsync(
        IObject entity)
    {
        throw new NotImplementedException();
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