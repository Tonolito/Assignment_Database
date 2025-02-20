namespace Domain.Models;

public class Customer
{
    public int CustomerId { get; set; } // LÄGG TILL
    public string CustomerName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
}
