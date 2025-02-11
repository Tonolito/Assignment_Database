using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string CustomerName { get; set; } = null!;

    
    [Column(TypeName = "nvarchar(50)")]
    public string CompanyName { get; set; } = null!;

    // (Parent)
    public ICollection<CustomerContactEntity> CustomerContacts { get; set; } = [];

    // (Parent)
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
