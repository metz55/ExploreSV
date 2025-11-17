using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int categoryId) : IRequest<int>;

