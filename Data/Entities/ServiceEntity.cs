using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ServiceName { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // (Child)
    [Required]
    public int UnitId { get; set; }
    public UnitEntity Unit { get; set; } = null!;

    // (Parent) 
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
