namespace Domain.UpdateDtos;

public class ServiceUpdateDto
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }
}
