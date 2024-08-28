using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    public IActionResult Index()
    {
        return View();
    }
}