using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUser;

internal sealed class GetUserHandler(IEfRepository<User> _repositry)
    : IRequestHandler<GetUserQuery, UserResponse>
{
    public async Task<UserResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _repositry.GetByIdAsync(query.UserId, cancellationToken);

        if (user is null)
        {
            return new UserResponse();
        }

        return user.Adapt<UserResponse>();
    }
}
