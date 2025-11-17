using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Commads.CreateUser;

public record CreateUserCommand(CreateUserRequest Request) : IRequest<int>;