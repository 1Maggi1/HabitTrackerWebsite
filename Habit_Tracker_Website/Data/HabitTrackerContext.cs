using Microsoft.EntityFrameworkCore;
using HabitTracker.Models;

namespace HabitTracker.Data;

public class HabitTrackerContext : DbContext
{
    public DbSet<Habit> Habits { get; set; }

    private readonly bool _useInMemory;

    public HabitTrackerContext()
    {

    }

    public HabitTrackerContext(bool useInMemory)
    {
        _useInMemory = useInMemory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_useInMemory)
        {
            optionsBuilder.UseInMemoryDatabase("HabitTracker");
        }
        else
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "persistence");
            Directory.CreateDirectory(basePath);
            var dbPath = Path.Combine(basePath, "habit_tracker.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

        }
    }
}
