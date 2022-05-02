using System.Net.Http.Json;
using Application.Contracts;
using Domain.Models;

namespace Application.Services;

public class CatFactService : ICatFactService
{
    private const string CatFactUrl = $"https://catfact.ninja/fact";

    public async Task<CatFact> GetFact()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetFromJsonAsync<CatFact>(CatFactUrl);

            return response ?? null!;
        }
    }
}