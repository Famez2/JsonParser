namespace JsonParser.Abstractions.Application.Interfaces;

public interface ISaveParseJsonService
{
    public Task ParseJson(
        string filePath);
}
