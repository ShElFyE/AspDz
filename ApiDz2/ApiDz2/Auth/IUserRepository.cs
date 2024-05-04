namespace ApiDz2.Auth
{
    public interface IUserRepository
    {
        UserDto GetUser(UserDto userModel);
    }
}
