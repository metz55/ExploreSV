using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Events.Commands.DeleteEvent;

public record DeleteEventCommand(int eventId) : IRequest<int>;

