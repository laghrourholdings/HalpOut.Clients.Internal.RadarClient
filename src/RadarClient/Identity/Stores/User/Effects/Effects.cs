using CommonLibrary.ClientServices.Identity;
using Fluxor;
// ReSharper disable UnusedParameter.Global

namespace RadarClient.Identity;

public class Effects
{
    private readonly ISecuroman _securoman;

    public Effects(ISecuroman securoman)
    {
        _securoman = securoman;
    }
    
    [EffectMethod(typeof(LoginUserByUsernameAction))]
    public async Task HandleLoginUserByUsernameAction(LoginUserByUsernameAction action, IDispatcher dispatcher)
    {
        if (_securoman.TrySignInWithUsername(action.Username, action.Password, out var user))
        {
            dispatcher.Dispatch(new AddUserAction {User = user});
        }
    }
    
    [EffectMethod(typeof(LoginUserByEmailAction))]
    public async Task LoginUserByEmailAction(LoginUserByEmailAction action, IDispatcher dispatcher)
    {
        if (_securoman.TrySignInWithEmail(action.Email, action.Password, out var user))
        {
            dispatcher.Dispatch(new AddUserAction {User = user});
        }
    }
    [EffectMethod(typeof(SignoutUserAction))]
    public async Task HandleSignOutAction(IDispatcher dispatcher)
    {
        _securoman.SignOut();
    }
}