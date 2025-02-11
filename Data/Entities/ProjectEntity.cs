using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{

    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ProjectNumber { get;} = null!;

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "Date")]
    public DateTime StartDate { get; set; }


    [Column(TypeName = "Date")]
    public DateTime EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    //(Child)
    [Required]
    public int StatusId { get; set; }
    public StatusTypeEntity Status { get; set; } = null!;

    // (Child)
    [Required]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    // (Child)
    [Required]
    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;

    // (Child)
    [Required]
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
   
   
    
}
