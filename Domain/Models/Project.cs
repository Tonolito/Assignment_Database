namespace Domain.Models;
// Display
public class Project
{
    // ID?
    public string ProjectNumber { get; } = null!;


    public string Title { get; set; } = null!;


    public string Description { get; set; } = null!;


    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }


    public decimal TotalPrice { get; set; }

    public string StatusName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string ServiceName { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

}

