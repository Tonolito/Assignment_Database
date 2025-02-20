using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Unit
{
    public int UnitId { get; set; }
    public string UnitName { get; set; } = null!;

}
