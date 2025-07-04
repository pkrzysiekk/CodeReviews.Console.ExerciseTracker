using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data;

public class ExerciseContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }

    public ExerciseContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ExerciseTracker.db");
    }
}