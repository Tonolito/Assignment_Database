

namespace Domain.Dtos;

public class ProjectDto
{
    // public int Id { get; set; } Ska man ha Id med?

  
    public string ProjectNumber { get; set; } = null!;

   
    public string Title { get; set; } = null!;

   
    public string Description { get; set; } = null!;

    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    
    public decimal TotalPrice { get; set; }

    public int StatusId { get; set; }

    public int UserId { get; set; }

    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

}
