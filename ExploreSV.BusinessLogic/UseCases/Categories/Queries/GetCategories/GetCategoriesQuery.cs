using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<PaginatedList<CategoryResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 6;
}