using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<PaginatedList<UserResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 6;
}