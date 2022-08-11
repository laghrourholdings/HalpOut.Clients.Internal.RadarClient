using CommonLibrary.Entities.InternalService;
using CommonLibrary.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Components;

namespace WebClient.Pages;

public partial class FetchData : ComponentBase
{
    private IEnumerable<IObject> _objects;
    

    protected override async Task OnInitializedAsync()
    {
        _objects = await _ObjectRepository.GetAllAsync();
    }
    
    private async Task OnCreateNewObjectAsync()
    {
        await _ObjectRepository.CreateAsync(null);
        _objects = await _ObjectRepository.GetAllAsync();
    }
}