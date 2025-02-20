namespace Domain.UpdateDtos;

public class CustomerUpdateDto
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
}


