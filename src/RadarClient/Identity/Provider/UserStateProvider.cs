using System.Security.Claims;
using CommonLibrary.ClientServices.Identity.AuthService;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using RadarClient.Identity.Stores.CurrentUserUseCase;

namespace RadarClient.Identity.Provider;

public class UserStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService _authService;

    private readonly IState<UserState> _userState;
    
    //private CurrentUser _currentUser;
    public UserStateProvider(IAuthService authService, IState<UserState> userState)
    {
        _authService = authService;
        _userState = userState;
    }
    // new Claim(ClaimTypes.Name, _currentUser.UserName) }.Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        try
        {
            if (_userState.Value.IsAuthenticated)
            {
                var claims = new[] { _userState.Value.UserClaims.Select(c => new Claim(c.Type, c.Value))};
                identity = new ClaimsIdentity((IEnumerable<Claim>?)claims, "Server authentication");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    public async Task Logout()
    {
        await _authService.Logout();
        //_currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task Login(/*LoginRequest loginParameters*/)
    {
        await _authService.Login(/*loginParameters*/);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task Register(/*RegisterRequest registerParameters*/)
    {
        await _authService.Register(/*registerParameters*/);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
