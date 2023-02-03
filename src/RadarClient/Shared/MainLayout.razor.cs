using Fluxor.Persist.Middleware;
using Microsoft.AspNetCore.Components;
using RadarClient.Identity;

namespace RadarClient.Shared;

public partial class MainLayout
{
    [Inject] 
    private UserStateProvider authStateProvider { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        SubscribeToAction<InitializePersistMiddlewareResultSuccessAction>(result =>
        {
            StateHasChanged();// we now have state, we can re-render to reflect binding changes
            authStateProvider.NotifyChanged();
        });
    }
}