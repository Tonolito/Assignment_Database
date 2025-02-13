using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class ServiceDto
{
 
    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

}
