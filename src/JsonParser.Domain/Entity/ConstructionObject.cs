namespace JsonParser.Domain.Entity;

public class ConstructionObject
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Session { get; set; }

    public string MetaData { get; set; }

    public string TextData { get; set; }

    public bool IsDeleted { get; set; }

    public int MetaCode { get; set; }

    public string DateRegistration { get; set; }

    public bool IsPushed { get; set; }

    public bool IsProcessed { get; set; }

    public bool BeProcessedApproved { get; set; }

    public bool BeOutgoingConfirmation { get; set; }

    public bool BeIncomingConfirmation { get; set; }

    public string BinaryData { get; set; }
}
