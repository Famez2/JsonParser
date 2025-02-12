namespace JsonParser.Abstractions.Application.Interfaces;

public interface ISaveConstructionObjectService
{
    public Task SaveConstructionObjectJson(string filePath);
}
