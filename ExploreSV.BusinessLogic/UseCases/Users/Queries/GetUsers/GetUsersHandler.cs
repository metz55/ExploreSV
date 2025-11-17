using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using ExploreSV.BusinessLogic.UseCases.Users.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUsers;

internal sealed class GetUsersHandler(IEfRepository<User> _repository)
    : IRequestHandler<GetUsersQuery, PaginatedList<UserResponse>>
{
    public async Task<PaginatedList<UserResponse>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        // Obtener el total de usuarios (sin paginar)
        var totalItems = await _repository.CountAsync(new GetUsersSpec(), cancellationToken);

        // Obtener los usuarios paginados (Skip + Take)
        var users = await _repository.ListAsync(
            new GetUsersSpec(
                skip: (query.PageNumber - 1) * query.PageSize,
                take: query.PageSize
            ),
            cancellationToken
        );

        // Validar si hay datos
        if (users == null || !users.Any())
        {
            return new PaginatedList<UserResponse>(
                new List<UserResponse>(),
                0,
                query.PageNumber,
                query.PageSize
            );
        }

        // Adaptar a DTOs
        var userResponses = users.Adapt<List<UserResponse>>();

        // Retornar la lista paginada
        return new PaginatedList<UserResponse>(
            userResponses,
            totalItems,
            query.PageNumber,
            query.PageSize
        );
    }
}