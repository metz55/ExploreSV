using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesGastronomies;
using ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageGastronomy;
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
    public class ImageGastronomyController : Controller
    {
       
        public class ImageEventController : Controller
        {
            private readonly IMediator _mediator;

            public ImageEventController(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<IActionResult> Index()
            {
                var images = await _mediator.Send(new GetImagesGastronomiesQuery(0, 1, 0));
                return View(images);
            }

            //GET: ImageGastronomyController/Create
            public ActionResult Create()
            {
                return View();
            }

            //POST: ImageGastronomyController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreateImageGastronomyRequest createImageGastronomyRequest)
            {
                try
                {
                    var result = await _mediator.Send(new CreateImageGastronomyCommand(createImageGastronomyRequest));
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        throw new Exception("Sucedio un error al intentar guardar la nueva imagen");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(createImageGastronomyRequest);
                }
            }

            //GET: ImageGastronomyController/Delete
            public async Task<IActionResult> Delete(int id)
            {
                var image = await _mediator.Send(new DeleteImageGastronomyCommand(id));
                return View(image);
            }

            //POST: ImageGastronomyController/Delete
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id, ImageGastronomyResponse imageGastronomyResponse)
            {
                try
                {
                    var result = await _mediator.Send(new DeleteImageGastronomyCommand(id));
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        throw new Exception("Sucedio un error al intentar eliminar el Imagen de Eventos");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(imageGastronomyResponse);
                }
            }

        }
    }
}
