namespace JsonParser.Abstractions.Application.Interfaces;

public interface ISaveConstructionObjectService
{
    public Task SaveParsedJson(
        string filePath);
}
