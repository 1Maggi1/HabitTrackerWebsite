using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using HabitTracker.Data;

namespace HabitTracker.Controllers;

public class HabitController : Controller
{
    private readonly HabitTrackerContext _context;

    public HabitController(HabitTrackerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return PartialView("_CreateHabitPartial");
    }

    [HttpPost]
    public IActionResult Create(Habit model)
    {
        if (model.Name != null && model.Description != null )
        {
            model.IsActive = true;
            model.CreatedAt = DateTime.Now;
            model.CompletedDates = new List<DateOnly>();

            _context.Habits.Add(model);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        // Bei Fehler gib die Partial View zurück
        return PartialView("_CreateHabitPartial", model);
    }
}