using Application.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Features.Commands;

public class GetAndSaveCatFactCommandHandler : IRequestHandler<GetAndSaveCatFactCommand, CatFact>
{
    private readonly ICatFactService _catFactService;
    private readonly ITextService _textService;

    public GetAndSaveCatFactCommandHandler(ICatFactService catFactService, ITextService textService)
    {
        _catFactService = catFactService;
        _textService = textService;
    }

    public async Task<CatFact> Handle(GetAndSaveCatFactCommand request, CancellationToken cancellationToken)
    {
        var fact = await _catFactService.GetFact();

        if (fact.Length > 0)
        {
            await _textService.SaveToFile(fact);
            return fact;
        }

        return null!;
    }
}