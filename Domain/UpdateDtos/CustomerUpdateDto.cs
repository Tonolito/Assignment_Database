namespace Domain.UpdateDtos;

public class CustomerUpdateDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
}


