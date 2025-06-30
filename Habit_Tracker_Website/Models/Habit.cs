namespace HabitTracker.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<DateOnly> completedDates { get; set; }
        public bool IsActive { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Habit habit && habit.Id == Id;
        }

    }
}