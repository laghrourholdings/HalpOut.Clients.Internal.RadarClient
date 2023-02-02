using Fluxor;
using Microsoft.AspNetCore.Components;
using RadarClient.Identity;

namespace RadarClient.Pages;

public partial class Counter
{
    [Inject]
    private IState<UserState> UserState { get; set; }
    [Inject]
    public IDispatcher Dispatcher { get; set; }
    
    [Inject] 
    private UserStateProvider authStateProvider { get; set; }

    private async void Login()
    {
        await authStateProvider.LoginWithUsername(UserName, Password);
    }
    
    private async void SignOut()
    {
        await authStateProvider.SignOut();
    }
}