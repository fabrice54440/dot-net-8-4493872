using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Com02_web.Models;

namespace Com02_web.Controllers;

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

    [HttpPost]
    public string Index([FromForm] FormulaireViewModel formulaire)
    {
        return $"Bien reçu la photo {formulaire.Titre} et le fichier {formulaire.Photo.Name} de {formulaire.Photo.Length} octets";
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
