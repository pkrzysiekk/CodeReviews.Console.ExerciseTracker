using ExerciseTracker.Models;
using Spectre.Console;
using System.Globalization;

using System.Globalization;

namespace ExerciseTracker.Menu.MenuHelpers;

public static class UserInput
{
    public static Exercise GetExercise()
    {
        string Description = AnsiConsole.Prompt(
            new TextPrompt<string>("What is the name of the exercise?"));
        bool areDatesValid = false;

        DateTime startExerciseDate = DateTime.MinValue;
        DateTime endExerciseDate = DateTime.MaxValue;

        while (!areDatesValid)
        {
            var startDate = AnsiConsole.Prompt(
                new TextPrompt<string>("What is the start date? (yyyy/MM/dd HH:mm:ss UTC)")
                    .Validate(input =>
                    {
                        return DateTime.TryParseExact(input, "yyyy/MM/dd HH:mm:ss UTC",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out var _)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Invalid date format[/]");
                    })
            );

            var endDate = AnsiConsole.Prompt(
                new TextPrompt<string>("What is the end date? (yyyy/MM/dd HH:mm:ss UTC)")
                    .Validate(input =>
                    {
                        return DateTime.TryParseExact(input, "yyyy/MM/dd HH:mm:ss UTC",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out var _)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Invalid date format[/]");
                    })
            );
            var parsedStartDate = DateTime.ParseExact(startDate, "yyyy/MM/dd HH:mm:ss UTC", CultureInfo.InvariantCulture);
            var parsedEndDate = DateTime.ParseExact(endDate, "yyyy/MM/dd HH:mm:ss UTC", CultureInfo.InvariantCulture);
            areDatesValid = parsedStartDate <= parsedEndDate && parsedEndDate <= DateTime.Now;
            startExerciseDate = parsedStartDate;
            endExerciseDate = parsedEndDate;
        }

        return new Exercise()
        {
            Description = Description,
            DateStart = startExerciseDate,
            DateEnd = endExerciseDate,
        };
    }
}