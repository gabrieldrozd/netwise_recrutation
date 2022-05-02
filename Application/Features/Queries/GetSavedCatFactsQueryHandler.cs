using Application.Contracts;
using MediatR;

namespace Application.Features.Queries;

public class GetSavedCatFactsQueryHandler : IRequestHandler<GetSavedCatFactsQuery, string>
{
    private readonly ITextService _textService;

    public GetSavedCatFactsQueryHandler(ITextService textService)
    {
        _textService = textService;
    }
    
    public async Task<string> Handle(GetSavedCatFactsQuery request, CancellationToken cancellationToken)
    {
        var savedFacts = await _textService.ReadFromFile();

        return savedFacts;
    }
}