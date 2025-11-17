using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesEvents;
using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageEvent;
using ExploreSV.BusinessLogic.UseCases.Images.Commands.DeleteImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExploreSV.BusinessLogic.DTOs;
using Mapster;
using ExploreSV.BusinessLogic.UseCases.Images.Commands.CreateImage;


namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class ImageEventController : Controller
    {
        private readonly IMediator _mediator;

        public ImageEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var images = await _mediator.Send(new GetImagesEventsQuery(0,0,1));
            return View(images);
        }

        //GET: ImageEventController/Create
        public ActionResult Create() 
        { 
            return View();
        }

        //POST: ImageEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateImageEventRequest createImageEventRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateImageEventCommand(createImageEventRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar la nueva imagen");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createImageEventRequest);
            }
        }

        //GET: ImageEventController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _mediator.Send(new DeleteImageEventCommand(id));
            return View(image);
        }

        //POST: ImageEventController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ImageEventResponse imageEventResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteImageEventCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Imagen de Eventos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(imageEventResponse);
            }
        }

    }
}
