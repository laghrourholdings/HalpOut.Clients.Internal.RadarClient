using System.Security.Claims;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;

namespace RadarClient.Identity;

public class UserStateProvider : AuthenticationStateProvider
{
    private readonly IDispatcher _dispatcher;

    private readonly IState<UserState> _userState;
    
    //private CurrentUser _currentUser;
    public UserStateProvider(IDispatcher dispatcher, IState<UserState> userState)
    {
        _dispatcher = dispatcher;
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
                identity = new ClaimsIdentity((IEnumerable<Claim>?)claims, "Securoman");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Request failed:" + ex.ToString());
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    public async Task SignOut()
    {
        _dispatcher.Dispatch(new SignoutUserAction());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task LoginWithUsername(string username, string password)
    {
        _dispatcher.Dispatch(new LoginUserByUsernameAction()
        {
            Username = username,
            Password = password
        });
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public async Task LoginWithEmail(string email, string password)
    {
        _dispatcher.Dispatch(new LoginUserByEmailAction()
        {
            Email = email,
            Password = password
        });
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    // public async Task Register(/*RegisterRequest registerParameters*/)
    // {
    //     await _authService.Register(/*registerParameters*/);
    //     NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    // }
}
