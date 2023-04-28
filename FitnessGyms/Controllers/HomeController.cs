using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessGyms.Models;

namespace FitnessGyms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        var model = new About()
        {
            Title = "FitnessGym Application",
            Description = "Description",
            Tags = new List<string>() { "Fitness", "BodyBuilding", "Pilates" }
        };

        return View(model);
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
}
