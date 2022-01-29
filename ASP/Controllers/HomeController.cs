using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp.Models;

namespace asp.Controllers;

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

   public IActionResult Connexion()
   {
      return View();
   }
   public IActionResult Toto()
   {
      return View();
   }
   public IActionResult Ratatouille(string courriel, string motdepasse)
   {
      // Identifiant marguerite = new Identifiant(courriel, motdepasse);
      Identifiant.guendoline.Add(new Identifiant(courriel, motdepasse));
      Identifiant.combien++;
      return View();
   }

   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   public IActionResult Error()
   {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
   }
}
