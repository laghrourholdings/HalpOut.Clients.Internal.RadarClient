using CommonLibrary.Identity.Models.Dtos;
using Fluxor;

namespace RadarClient.Identity;

[FeatureState]
public class UserState
{
    public bool IsAuthenticated { get ; set; }
    public Guid Id {  get;  set; }
    public Guid LogHandleId {  get;  set; }
    public List<UserClaim> UserClaims {  get;  set; }
    
    
    public UserState()// Required for creating initial state
    {
        IsAuthenticated = false;
        UserClaims = new List<UserClaim>();
        Id = Guid.Empty;
        LogHandleId = Guid.Empty;
    }
    
    public UserState(Guid userId, Guid logHandleId, List<UserClaim> userClaims, bool isAuthenticated)  // Required for creating initial state
    {
        Id = userId;
        LogHandleId = logHandleId;
        UserClaims = userClaims;
        IsAuthenticated = isAuthenticated;
    }
}
