using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Users.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUserAuthenticated;

internal sealed class GetUserAuthenticatedHandler(IEfRepository<User> _repository)
    : IRequestHandler<GetUserAuthenticatedQuery, UserResponse>
{
    public async Task<UserResponse> Handle(GetUserAuthenticatedQuery query, CancellationToken cancellationToken)
    {
        var user = await _repository
            .FirstOrDefaultAsync(
                new GetUserAuthenticatedSpec(query.userName, query.userPassword),
                cancellationToken
            );
        if ( user is null )
        {
            return new UserResponse();
        }
        return user.Adapt<UserResponse>();
    }
}