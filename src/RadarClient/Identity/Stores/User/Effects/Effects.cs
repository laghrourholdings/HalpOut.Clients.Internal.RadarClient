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
    
    [EffectMethod]
    public async Task HandleLoginUserByUsernameAction(LoginUserByUsernameAction action, IDispatcher dispatcher)
    {
        var user = await _securoman.SignInWithUsername(action.Username, action.Password);
        if(user!=null)
            dispatcher.Dispatch(new AddUserAction {User = user});
    }
    
    [EffectMethod]
    public async Task LoginUserByEmailAction(LoginUserByEmailAction action, IDispatcher dispatcher)
    {
        var user = await _securoman.SignInWithEmail(action.Email, action.Password);
        if(user!=null)
            dispatcher.Dispatch(new AddUserAction {User = user});
    }
    [EffectMethod(typeof(SignoutUserAction))]
    public async Task HandleSignOutAction(IDispatcher dispatcher)
    {
        _securoman.SignOut();
        dispatcher.Dispatch(new RemoveUserAction());
    }
}