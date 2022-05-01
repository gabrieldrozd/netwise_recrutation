using System.Text;
using System.Text.Json;
using Application.Contracts;
using Domain.Models;

namespace FileData;

public class TextService : ITextService
{
    private const string CatFactFileName = "cat_facts.txt";

    public async Task SaveToFile(CatFact fact)
    {
        if (!File.Exists(CatFactFileName))
        {
            await using (StreamWriter sw = File.CreateText(CatFactFileName))
            {
                await sw.WriteLineAsync(fact.ToString());
            }
        }
        else if (File.Exists(CatFactFileName))
        {
            await using (StreamWriter sw = File.AppendText(CatFactFileName))
            {
                await sw.WriteLineAsync(fact.ToString());
            }
        }
    }

    public async Task<string> ReadFromFile()
    {
        if (File.Exists(CatFactFileName))
        {
            using (StreamReader sr = File.OpenText(CatFactFileName))
            {
                var test = await sr.ReadToEndAsync();
                return test;
            }
        }

        return null;
    }
}