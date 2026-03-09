namespace Yusr.Core.Abstractions.Entities
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        bool IsActive { get; set; }
        long RoleId { get; set; }

        IRole Role { get; set; }
    }
}
