using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatus;

public record GetStatusQuery(int statusId) : IRequest<StatusResponse>;