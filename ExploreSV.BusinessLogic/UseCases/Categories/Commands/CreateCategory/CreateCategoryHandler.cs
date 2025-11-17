using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(IEfRepository<Category> _repository)
    : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newCategory = command.Request.Adapt<Category>();
            var createCategory = await _repository.AddAsync(newCategory, cancellationToken);
            return createCategory.CategoryId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}