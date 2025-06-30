using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;

namespace HabitTracker.Controllers;

public class StatisticsController : Controller
{

    public StatisticsController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }
}
