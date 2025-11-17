using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestinations;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.CreateGastronomy;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.UpdateGastronomy;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.DeleteGastronomy;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomy;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomies;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class GastronomyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment; //Inyeccion q sirve para el guardado de images
        
        public GastronomyController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        //GET: GastronomyController
        public async Task<IActionResult> Index()
        {
            var gastronomies = await _mediator.Send(new GetGastronomiesQuery());
            return View(gastronomies);
        }

        //GET: GastronomyController/Create
        public async Task<IActionResult> Create()
        {
            var gastronomies = await _mediator.Send(new GetGastronomiesQuery());
            return View();
        }

        //Metodo SaveImage
        public async Task<string> SaveImage(IFormFile? file, string url = "")
        {
            string urlImage = url;
            if (file != null && file.Length > 0)
            {
                //Construir la ruta del archivo
                string nameFile = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", nameFile);

                //Guardar la imagen en wwwroot
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                //Guardar la ruta en la base de datos
                urlImage = "/images" + nameFile;
            }
            return urlImage;
        }

        //POST: GastronomyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGastronomyRequest createGastronomyRequest, List<IFormFile>? files = null)
        {
            try
            {
                if (files != null)
                {
                    foreach (var file in files) {
                        createGastronomyRequest.Images.Add(new CreateImageGastronomyRequest
                        {
                            ImageUrl = await SaveImage(file)
                        });
                    }
                }

                var result = await _mediator.Send(new CreateGastronomyCommand(createGastronomyRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar la nueva gastronomia");
            }
            catch (Exception ex)
            {
                var gastronomies = await _mediator.Send(new GetGastronomiesQuery());
                ModelState.AddModelError("", ex.Message);
                return View(createGastronomyRequest);
            }
        }

        //GET: GastronomyController/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var gastronomy = await _mediator.Send(new GetGastronomyQuery(id));

            var d = gastronomy.TouristDestinationTitle;
            ViewData["TouristDestinationTitle"] = gastronomy.TouristDestinationTitle;
            
            return View(gastronomy.Adapt(new UpdateGastronomyRequest()));
        }

        //POST: GastronomyController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateGastronomyRequest updateGastronomyRequest, List<IFormFile>? files = null)
        {
            try
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        updateGastronomyRequest.Images.Add(new CreateImageGastronomyRequest
                        {
                            ImageUrl = await SaveImage(file)
                        });
                    }
                }

                var result = await _mediator.Send(new UpdateGastronomyCommand(updateGastronomyRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar editar la gastronomia");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateGastronomyRequest);
            }
        }

        //GET: GastronomyController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var gastronomy = await _mediator.Send(new GetGastronomyQuery(id));
            return View(gastronomy);
        }

        //POST: GastronomyController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GastronomyResponse gastronomyResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteGastronomyCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar la gastronomia");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(gastronomyResponse);
            }
        }
    }
}