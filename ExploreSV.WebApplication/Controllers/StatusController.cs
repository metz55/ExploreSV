using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Statuses.Commands.CreateStatus;
using ExploreSV.BusinessLogic.UseCases.Statuses.Commands.DeleteStatus;
using ExploreSV.BusinessLogic.UseCases.Statuses.Commands.UpdateStatus;
using ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatus;
using ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatuses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var statuses = await _mediator.Send(new GetStatusesQuery());
            return View(statuses);
        }

        //GET: StatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: StatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStatusRequest createStatusRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateStatusCommand(createStatusRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo Estado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createStatusRequest);
            }
        }

        //GET: StatusController/Edit
        public async Task<IActionResult> Edit(int Id)
        {
            var status = await _mediator.Send(new GetStatusQuery(Id));
            return View(status.Adapt(new UpdateStatusRequest()));
        }

        //POST: StatustController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateStatusRequest updateStatusRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateStatusCommand(updateStatusRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar editar estado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateStatusRequest);
            }
        }


        //GET: StatusController/Delete
        public async Task<IActionResult> Delete(int Id)
        {
            var status = await _mediator.Send(new GetStatusQuery(Id));
            return View(status);
        }

        //POST: StatusController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, StatusResponse statusResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteStatusCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Estado");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(statusResponse);
            }
        }
    }
}

