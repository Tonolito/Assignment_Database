using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Service
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Unitid { get; set; }
    public string UnitName { get; set; } = null!;
}
