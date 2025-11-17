using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUserAuthenticated;

public record GetUserAuthenticatedQuery(string userName, string userPassword)
    : IRequest<UserResponse>;