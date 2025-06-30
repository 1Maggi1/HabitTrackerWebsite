using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using HabitTracker.Data.Habits;

namespace HabitTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseHabitRepository _habitRepository;

    public HomeController(ILogger<HomeController> logger, DatabaseHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_habitRepository.GetAllHabits());
    }

    public IActionResult Statistics()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
