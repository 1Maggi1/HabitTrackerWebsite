namespace HabitTracker.Models;

public class HomeViewModel

{
    public IEnumerable<Habit> Habits { get; set; } = new List<Habit>();
    public Dictionary<DateOnly, int> CompletedHabitsByDay { get; set; } = new();
    public Dictionary<DateOnly, List<Habit>> CompletedHabitsPerDay { get; set; } = new();
}