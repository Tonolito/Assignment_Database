using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class StatusTypeDto
{   
    public string StatusName { get; set; } = null!;

}
