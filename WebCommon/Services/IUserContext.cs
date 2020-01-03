namespace WebCommon.Services
{
    public interface IUserContext
    {
        int UserId { get; }
        int UserTypeId { get; }
        string Email { get; }
        string FullName { get; }

        bool IsInRole(string role);
    }

}
