using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.UpdateGastronomy;

internal sealed class UpdateGastronomyHandler(IEfRepository<Gastronomy> _repository)
    : IRequestHandler<UpdateGastronomyCommand, int>
{
    public async Task<int> Handle(UpdateGastronomyCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingGastronomy = await _repository.GetByIdAsync(command.Request.GastronomyId);

            if (existingGastronomy is null) return 0;

            existingGastronomy = command.Request.Adapt(existingGastronomy);

            await _repository.UpdateAsync(existingGastronomy, cancellationToken);

            return existingGastronomy.GastronomyId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}