using Domain.Models;

namespace Application.Contracts;

public interface ICatFactService
{
    Task<CatFact> GetFact();
}