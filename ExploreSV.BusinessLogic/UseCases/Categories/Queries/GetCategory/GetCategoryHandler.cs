using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategory;

internal sealed class GetCategoryHandler(IEfRepository<Category> _repository)
    : IRequestHandler<GetCategoryQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(query.categoryId, cancellationToken);

        if (category is null)
        {
            return new CategoryResponse();
        }
        return category.Adapt<CategoryResponse>();
    }
}

