using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Commands.CreateTouristDestination;

internal sealed class CreateTouristDestinationHandler(IEfRepository<TouristDestination> _repository)
    : IRequestHandler<CreateTouristDestinationCommand, int>
{
    public async Task<int> Handle(CreateTouristDestinationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newTouristDestination = command.Request.Adapt<TouristDestination>();

            newTouristDestination.StatusId = 1;

            var createTouristDestination = await _repository.AddAsync(newTouristDestination, cancellationToken);


            return createTouristDestination.TouristDestinationId;
        }
        catch (Exception ex)
        {
            return 0;
            throw;
        }
    }
}