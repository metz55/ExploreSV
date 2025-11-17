using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategories;
using ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartments;
using ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvents;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomies;
using ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatuses;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Commands.CreateTouristDestination;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Commands.UpdateTouristDestination;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestination;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestinations;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class TouristDestinationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TouristDestinationController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        //GET: TouristDestinationController
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
        {
            var query = new GetTouristDestinationsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var touristDestinations = await _mediator.Send(query);
            return View(touristDestinations);
        }

        //GET: TouristDestinationController/Create
        public async Task<IActionResult> Create()
        {

            var categoriesResult = await _mediator.Send(new GetCategoriesQuery());
            ViewData["CategoryId"] = new SelectList(categoriesResult.Items, "CategoryId", "CategoryName");
            

            var departmentsResult = await _mediator.Send(new GetDepartmentsQuery());
            ViewData["DepartmentId"] = new SelectList(departmentsResult.Items, "DepartmentId", "DepartamentName");
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
                urlImage = "/images/" + nameFile;
            }
            return urlImage;
        }

        //POST: TouristDestinationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTouristDestinationRequest createTouristDestinationRequest, List<IFormFile>? files = null)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                int userId = userIdClaim != null ? int.Parse(userIdClaim) : 0;

                createTouristDestinationRequest.StatusId = 1;
                createTouristDestinationRequest.UserId = userId;

                //Verifica q images este inicializado
                if (createTouristDestinationRequest.Images == null)
                {
                    createTouristDestinationRequest.Images = new List<CreateImageTouristDestinationRequest>();
                }

                //Verifica si se subio un archivo
                if (files != null && files.Any())
                {
                    foreach (var file in files)
                    {
                        // Guardar la imagen y agregarla a la lista de imágenes
                        createTouristDestinationRequest.Images.Add(new CreateImageTouristDestinationRequest
                        {
                            ImageUrl = await SaveImage(file)
                        });
                    }
                }

                var result = await _mediator.Send(new CreateTouristDestinationCommand(createTouristDestinationRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo destino turistico");
            }
            catch (Exception ex)
            {
                // Cargar categorías y departamentos nuevamente en caso de error
                var categoriesResult = await _mediator.Send(new GetCategoriesQuery());
                var departmentsResult = await _mediator.Send(new GetDepartmentsQuery());

                ViewBag.Categories = new SelectList(categoriesResult.Items ?? new List<CategoryResponse>(), "CategoryId", "CategoryName");
                ViewBag.Departments = new SelectList(departmentsResult.Items ?? new List<DepartmentResponse>(), "DepartmentId", "DepartamentName");

                ModelState.AddModelError("", ex.Message);
                return View(createTouristDestinationRequest);
            }
        }

        //GET: TouristDestinationController/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var touristDestination = await _mediator.Send(new GetTouristDestinationQuery(id));

            var statuses = await _mediator.Send(new GetStatusesQuery());
            ViewData["StatusId"] = new SelectList(statuses, "StatusId", "StatusName", touristDestination.StatusId);

            var categoriesResult = await _mediator.Send(new GetCategoriesQuery());
            ViewData["CategoryId"] = new SelectList(categoriesResult.Items, "CategoryId", "CategoryName", touristDestination.CategoryId);

            var departmentsResult = await _mediator.Send(new GetDepartmentsQuery());
            ViewData["DepartmentId"] = new SelectList(departmentsResult.Items, "DepartmentId", "DepartamentName", touristDestination.DepartmentId);

            //Mapeo con las imagenes
            var updateRequest = touristDestination.Adapt<UpdateTouristDestinationRequest>();

            // Pasar las imágenes existentes al request
            if (touristDestination.Images != null)
            {
                updateRequest.Images = touristDestination.Images
                .Select(img => new CreateImageTouristDestinationRequest { ImageUrl = img.ImageUrl })
                .ToList();
            }
            return View(updateRequest);
        }

        //POST: TouristDestinationController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTouristDestinationRequest updateTouristDestinationRequest, List<IFormFile>? files = null)
        {
            try
            {
                // Recuperar imágenes existentes del destino antes de agregar nuevas
                var existingDestination = await _mediator.Send(new GetTouristDestinationQuery(updateTouristDestinationRequest.TouristDestinationId));

                if (updateTouristDestinationRequest.Images == null)
                {
                    updateTouristDestinationRequest.Images = new List<CreateImageTouristDestinationRequest>();
                }

                // Mantener las imágenes existentes y agregar nuevas si es necesario
                foreach (var img in existingDestination.Images)
                {
                    updateTouristDestinationRequest.Images.Add(new CreateImageTouristDestinationRequest { ImageUrl = img.ImageUrl });
                }

                if (files != null && files.Any())
                {
                    foreach (var file in files)
                    {
                        // Llamar al método SaveImage para guardar las nuevas imágenes
                        updateTouristDestinationRequest.Images.Add(new CreateImageTouristDestinationRequest
                        {
                            ImageUrl = await SaveImage(file)// Guardar imagen y agregar la URL a la lista
                        });
                    }
                }

                var result = await _mediator.Send(new UpdateTouristDestinationCommand(updateTouristDestinationRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar editar el destino turistico");
            }
            catch (Exception ex)
            {

                var statuses = await _mediator.Send(new GetStatusesQuery()); // tenia punto
                ViewData["StatusId"] = new SelectList(statuses, "StatusId", "StatusName", updateTouristDestinationRequest.StatusId);

                var categoriesResult = await _mediator.Send(new GetCategoriesQuery());
                ViewData["CategoryId"] = new SelectList(categoriesResult.Items, "CategoryId", "CategoryName", updateTouristDestinationRequest.CategoryId);

                var departmentsResult = await _mediator.Send(new GetDepartmentsQuery());
                ViewData["DepartmentId"] = new SelectList(departmentsResult.Items, "DepartamentId", "DepartamentName", updateTouristDestinationRequest.DepartmentId);

                ModelState.AddModelError("", ex.Message);
                return View(updateTouristDestinationRequest);
            }
        }

        // GET: TouristDestinationController/Details/{id}
        [AllowAnonymous] //Sirve para acceder sin estar con la sesion iniciada
        public async Task<IActionResult> Details(int id)
        {
            var touristDestination = await _mediator.Send(new GetTouristDestinationQuery(id));

            if (touristDestination == null) // tenia punto
            {
                return NotFound();
            }
            return View(touristDestination);
        }
    }
}