using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Users.Commads.DeleteUser;

public record DeleteUserCommand(int UserId) : IRequest<int>;