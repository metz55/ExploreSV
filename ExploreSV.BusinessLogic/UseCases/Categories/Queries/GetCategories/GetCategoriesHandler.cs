using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.Specifications;
using ExploreSV.BusinessLogic.Utils;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategories
{
    internal sealed class GetCategoriesHandler(IEfRepository<Category> _repository)
        : IRequestHandler<GetCategoriesQuery, PaginatedList<CategoryResponse>>
    {
        public async Task<PaginatedList<CategoryResponse>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            // Obtener el total de categorías (sin paginar)
            var totalItems = await _repository.CountAsync(new GetCategoriesSpec(), cancellationToken);

            // Obtener las categorías paginadas (Skip + Take)
            var categories = await _repository.ListAsync(
                new GetCategoriesSpec(
                    skip: (query.PageNumber - 1) * query.PageSize,
                    take: query.PageSize,
                    CategoryId: 0
                ),
                cancellationToken
            );

            // Validar si hay datos
            if (categories == null || !categories.Any())
            {
                return new PaginatedList<CategoryResponse>(
                    new List<CategoryResponse>(),
                    0,
                    query.PageNumber,
                    query.PageSize
                );
            }

            // Adaptar a DTOs
            var categoryResponses = categories.Adapt<List<CategoryResponse>>();

            // Retornar la lista paginada
            return new PaginatedList<CategoryResponse>(
                categoryResponses,
                totalItems,
                query.PageNumber,
                query.PageSize
            );
        }
    }
}