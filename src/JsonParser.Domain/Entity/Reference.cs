using JsonParser.Domain.Entit;

namespace JsonParser.Domain.Entity;

public class Reference
{
    public Guid Id { get; set; }

    public string Group { get; set; }

    public string Name { get; set; }

    public string Method { get; set; }

    public List<Knot> Knotes { get; set; } = [];
}
