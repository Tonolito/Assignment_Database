namespace Domain.UpdateDtos;

public class ProjectUpdateDto
{
    public int Id { get; set; }

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


