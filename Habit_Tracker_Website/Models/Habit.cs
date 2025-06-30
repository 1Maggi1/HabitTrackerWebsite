using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Models;

public class Habit
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public required string Description { get; set; }

    [Required]
    public DateTime? CreatedAt { get; set; }

    [Required]
    public List<DateOnly> CompletedDates { get; set; } = new();

    [Required]
    public bool IsActive { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Habit habit && habit.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    }