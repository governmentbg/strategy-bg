namespace WebCommon.Services
{
    public interface IUserContext
    {
        int UserId { get; }
        string Email { get; }
        string FullName { get; }

        bool IsInRole(string role);
    }

}
