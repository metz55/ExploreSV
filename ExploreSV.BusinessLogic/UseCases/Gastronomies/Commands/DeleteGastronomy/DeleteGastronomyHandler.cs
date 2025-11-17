using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.DeleteGastronomy;

internal sealed class DeleteGastronomyHandler(IEfRepository<Gastronomy> _repository)
    : IRequestHandler<DeleteGastronomyCommand, int>
{
    public async Task<int> Handle(DeleteGastronomyCommand command, CancellationToken cancellationToken)
    {
        var existingGastronomy = await _repository.GetByIdAsync(command.GastronomyId);

        if (existingGastronomy is null) return 0;

        await _repository.DeleteAsync(existingGastronomy, cancellationToken);

        return existingGastronomy.GastronomyId;
    }
}