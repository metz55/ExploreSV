using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesTouristDestinations;
using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageTouristDestination;
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
    public class ImageTouristDestinationController : Controller
    {
        private readonly IMediator _mediator;
        public ImageTouristDestinationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var images = await _mediator.Send(new GetImagesTouristDestinationsQuery(1, 0, 0));
            return View(images);
        }

        //GET: ImageTouristDestinationController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: ImageTouristDestinationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateImageTouristDestinationRequest createImageTouristDestinationRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateImageTouristDestinationCommand(createImageTouristDestinationRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar la nueva imagen");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createImageTouristDestinationRequest);
            }
        }

        //GET: ImageTouristDestinationController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _mediator.Send(new DeleteImageTouristDestinationCommand(id));
            return View(image);
        }

        //POST: ImageTouristDestinationController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ImageTouristDestinationResponse imageTouristDestinationResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteImageTouristDestinationCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Imagen de Eventos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(imageTouristDestinationResponse);
            }
        }

    }
}
