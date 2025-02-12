using JsonParser.Domain.Entity;

namespace JsonParser.Domain.Entit;

public class Knot
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public Guid ReferenceId { get; set; }

    public Reference Reference { get; set; }
}
