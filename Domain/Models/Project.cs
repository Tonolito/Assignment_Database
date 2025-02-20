namespace Domain.Models;
// Display
public class Project
{
    public int ProjectId { get; set; }
    public string ProjectNumber { get; set; } = null!;


    public string Title { get; set; } = null!;


    public string Description { get; set; } = null!;


    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }


    public decimal TotalPrice { get; set; }

    public int StatusId { get; set; }
    public string StatusName { get; set; } = null!;

    public int UserId { get; set; }
    public string UserName { get; set; } = null!;

    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

}

