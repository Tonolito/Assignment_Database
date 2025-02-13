using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Service
{

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

}
