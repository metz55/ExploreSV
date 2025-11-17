using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Commands.DeleteCategory;

internal sealed class DeleteCategoryHandler(IEfRepository<Category> _repository)
    : IRequestHandler<DeleteCategoryCommand, int>
{
    public async Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var existingCategory = await _repository.GetByIdAsync(command.categoryId);
        if (existingCategory is null) return 0;
        await _repository.DeleteAsync(existingCategory, cancellationToken);
        return existingCategory.CategoryId;
    }
}
