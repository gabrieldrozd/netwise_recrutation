using Domain.Models;
using MediatR;

namespace Application.Features.Commands;

public class GetAndSaveCatFactCommand : IRequest<CatFact>
{
}