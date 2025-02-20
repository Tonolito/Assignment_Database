namespace Domain.Models;

public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;

}
