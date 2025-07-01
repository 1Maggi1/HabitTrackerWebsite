
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Controllers;

public class SettingsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}