namespace Domain.UpdateDtos;

public class UserUpdateDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }
}
