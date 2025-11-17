using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.CreateGastronomy;

internal sealed class CreateGastronomyHandler(IEfRepository<Gastronomy> _repository)
    : IRequestHandler<CreateGastronomyCommand, int>
{
    public async Task<int> Handle(CreateGastronomyCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newGastronomy = command.Request.Adapt<Gastronomy>();

            var createGastronomy = await _repository.AddAsync(newGastronomy, cancellationToken);

            return createGastronomy.GastronomyId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}