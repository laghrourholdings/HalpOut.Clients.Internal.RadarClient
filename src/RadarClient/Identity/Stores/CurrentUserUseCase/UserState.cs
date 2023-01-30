using CommonLibrary.Identity.Models.Dtos;
using Fluxor;

namespace RadarClient.Identity.Stores.CurrentUserUseCase;

[FeatureState]
public class UserState
{
    public bool IsAuthenticated {  get;  set; }
    public Guid Id {  get;  set; }
    public Guid LogHandleId {  get;  set; }
    public List<UserClaim> UserClaims {  get;  set; }
    
    private UserState()// Required for creating initial state
    {
        IsAuthenticated = false;
    }
    
    public UserState(Guid UserId, Guid logHandleId, List<UserClaim> userClaims)  // Required for creating initial state
    {
        Id = UserId;
        LogHandleId = logHandleId;
        UserClaims = userClaims;
        IsAuthenticated = true;
    }
}
