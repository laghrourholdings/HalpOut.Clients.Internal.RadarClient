using Fluxor.Persist.Middleware;
using Microsoft.AspNetCore.Components;
using RadarClient.Identity;

namespace RadarClient.Shared;

public partial class MainLayout
{

    protected override async Task OnInitializedAsync()
    {
        StateHasChanged();// we now have state, we can re-render to reflect binding changes
        authStateProvider.NotifyChanged();
    }
}