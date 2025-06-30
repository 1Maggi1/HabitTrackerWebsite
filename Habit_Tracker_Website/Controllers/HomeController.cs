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
        var habits = _habitRepository.GetAllHabits();

        var completedHabitsPerDay = habits
            .SelectMany(h => h.CompletedDates.Select(date => new { Habit = h, Date = date }))
            .GroupBy(x => x.Date)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Habit).ToList());

        var completedHabitsByDay = completedHabitsPerDay.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);

        var vm = new HomeViewModel
        {
            Habits = habits,
            CompletedHabitsByDay = completedHabitsByDay,
            CompletedHabitsPerDay = completedHabitsPerDay
        };

        return View(vm);
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
