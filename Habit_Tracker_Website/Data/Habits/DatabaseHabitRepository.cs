using HabitTracker.Models;

namespace HabitTracker.Data.Habits;

public class DatabaseHabitRepository(HabitTrackerContext context)
{
    public IEnumerable<Habit> GetAllHabits()
    {
        return context.Habits.ToList();
    }
    
    public void Create(Habit habit)
    {
        if (habit == null || Exists(habit) || Exists(habit.Id))
        {
            throw new ArgumentException("Habit is null or already exists.");
        }
        context.Habits.Add(habit);
        context.SaveChanges();
    }

    public bool Exists(int habitId)
    {
        return context.Habits.Any(t => t.Id == habitId);
    }

    public bool Exists(Habit habit)
    {
        return context.Habits.Any(t => t.Equals(habit));
    }

    public void Update(Habit habit)
    {
        var existingHabit = context.Habits.Find(habit.Id);
        if (existingHabit != null)
        {
            existingHabit.completedDates.Add(DateOnly.FromDateTime(DateTime.Now));
        }
        context.SaveChanges();
    }
    
    public void Delete(int habitId)
    {
        var habit = context.Habits.Find(habitId);
        if (habit != null)
        {
            context.Habits.Remove(habit);
            context.SaveChanges();
        }
    }

    public void Delete(Habit habit)
    {
        if (context.Habits.Contains(habit))
        {
            context.Habits.Remove(habit);
            context.SaveChanges();
        }
    }

    public Habit? GetHabitById(int habitId)
    {
        return context.Habits.Find(habitId);
    }
}
