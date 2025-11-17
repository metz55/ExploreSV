using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Queries.GetUser;

public record GetUserQuery(int UserId) : IRequest<UserResponse>;


