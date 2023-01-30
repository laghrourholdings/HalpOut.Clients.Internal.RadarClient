using Fluxor;

namespace RadarClient.Identity.Stores.CurrentUserUseCase.Reducers;

public class Reducers
{
    [ReducerMethod]
    public static UserState ReduceIncrementCounterAction(UserState state, AddUserAction action) =>
        new UserState(action.User.Id, action.User.LogHandleId, action.User.UserClaims);
}