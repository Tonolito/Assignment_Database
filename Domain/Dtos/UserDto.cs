using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UserDto
{
   
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }
}
