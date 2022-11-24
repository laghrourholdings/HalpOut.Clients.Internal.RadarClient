using CommonLibrary.Core;
using Microsoft.AspNetCore.Components;

namespace WebClient.Pages;

public partial class FetchData : ComponentBase
{
    private IEnumerable<IIObject>? _objects;
    
    protected override async Task OnInitializedAsync()
    {
        _objects = await _objectRepository.GetAllAsync();
    }
    
    private async Task OnCreateNewObjectAsync()
    {
        await _objectRepository.CreateAsync(null);
        _objects = await _objectRepository.GetAllAsync();
    }
}