using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvent;
public record GetEventQuery(int EventId) : IRequest<EventResponse>;

