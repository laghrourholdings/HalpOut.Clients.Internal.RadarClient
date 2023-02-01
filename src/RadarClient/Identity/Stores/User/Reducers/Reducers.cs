using Fluxor;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace RadarClient.Identity;

public class Reducers
{
    [ReducerMethod]
    public static UserState ReduceAddUserAction(UserState state, AddUserAction action) =>
        new(
            userId: action.User.Id,
            logHandleId: action.User.LogHandleId,
            userClaims: action.User.UserClaims,
            isAuthenticated: true);
    
    [ReducerMethod]
    public static UserState ReduceRemoveUserAction(UserState state, RemoveUserAction action) =>
        new();
}