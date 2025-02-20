namespace Domain.UpdateDtos;

public class ServiceUpdateDto
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public int UnitId { get; set; }
}
