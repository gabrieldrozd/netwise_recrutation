using Application.Contracts;
using Domain.Models;

namespace FileData;

public class TextService : ITextService
{
    private static readonly DirectoryInfo Current = Directory.GetParent(Environment.CurrentDirectory);
    private static readonly string FilePath = Path.Combine(Current.ToString(), "FileData", "Data", "cat_facts.txt");

    public async Task SaveToFile(CatFact fact)
    {
        if (!File.Exists(FilePath))
        {
            await using (var sw = File.CreateText(FilePath))
            {
                await sw.WriteLineAsync(fact.ToString());
            }
        }
        else if (File.Exists(FilePath))
        {
            await using (var sw = File.AppendText(FilePath))
            {
                await sw.WriteLineAsync(fact.ToString());
            }
        }
    }

    public async Task<string> ReadFromFile()
    {
        if (File.Exists(FilePath))
        {
            using (var sr = File.OpenText(FilePath))
            {
                var facts = await sr.ReadToEndAsync();
                return facts;
            }
        }

        return null;
    }
}