using CommonLibrary.ClientServices.Identity;

namespace RadarClient.Identity;

public class AddUserAction
{
    public User User { get; set;}
}

public class RemoveUserAction
{
}

public class LoginUserByEmailAction
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserByUsernameAction
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class SignoutUserAction
{
}