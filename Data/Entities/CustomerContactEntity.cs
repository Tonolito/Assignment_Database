using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerContactEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string PhoneNumber { get; set; } = null!;

    //(child)
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
}
