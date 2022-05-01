using Domain.Models;

namespace Application.Contracts;

public interface ITextService
{
    /// <summary>
    /// Save formatted and deserialized HTTP Response to file
    /// </summary>
    /// <param name="fact">object of type CatFact</param>
    Task SaveToFile(CatFact fact);
    
    /// <summary>
    /// Read all file contents
    /// </summary>
    /// <returns>File contents as string</returns>
    Task<string> ReadFromFile();
}