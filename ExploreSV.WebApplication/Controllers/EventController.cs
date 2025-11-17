using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Events.Commands.CreateEvent;
using ExploreSV.BusinessLogic.UseCases.Events.Commands.DeleteEvent;
using ExploreSV.BusinessLogic.UseCases.Events.Commands.UpdateEvent;
using ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvent;
using ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvents;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ExploreSV.WebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _mediator.Send(new GetEventsQuery());
            return View(events);
        }

        //GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventRequest createEventRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateEventCommand(createEventRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo Evento");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createEventRequest);
            }
        }

        //GET: EventController/Event
        public async Task<IActionResult> Edit(int Id)
        {
            var Event = await _mediator.Send(new GetEventQuery(Id));
            return View(Event.Adapt(new UpdateEventRequest()));
        }
      

        //POST: EventController/Event




        //GET: EventController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var Event = await _mediator.Send(new GetEventQuery(id));
            return View(Event);
        }

        //POST: EventController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, EventResponse EventResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteEventCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Departamento");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(EventResponse);
            }
        }
    }
}
