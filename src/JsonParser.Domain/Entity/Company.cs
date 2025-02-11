namespace JsonParser.Domain.Entity;

public class Company
{
    public Guid Id { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}

