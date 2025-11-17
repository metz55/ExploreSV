using ExploreSV.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestinations;
using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using Mapster;

namespace ExploreSV.WebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator; 

    public HomeController(ILogger<HomeController> logger, IMediator sender)
    {
        _logger = logger;
        _mediator = sender;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
    {
        var query = new GetTouristDestinationsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var touristDestinations = await _mediator.Send(query);
        return View(touristDestinations);

        //var touristDestinations = await _mediator.Send(new GetTouristDestinationsQuery());
        //return View(touristDestinations);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult MisionVision()
    {
        return View("~/Views/Home/MisionVision.cshtml");
    }
}