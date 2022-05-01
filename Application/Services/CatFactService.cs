using System.Net.Http.Json;
using Application.Contracts;
using Domain.Models;

namespace Application.Services;

public class CatFactService : ICatFactService
{
    private const string CatFactUrl = $"https://catfact.ninja/fact";
    private readonly ITextService _textService;

    public CatFactService(ITextService textService)
    {
        _textService = textService;
    }

    public async Task<CatFact> GetFact()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetFromJsonAsync<CatFact>(CatFactUrl);

            if (response != null)
            {
                await _textService.SaveToFile(response);
                return response;
            }

            return null!;
        }
    }

    public async Task<string> GetSavedToFileFacts()
    {
        var savedFacts = await _textService.ReadFromFile();

        return savedFacts;
    }
}