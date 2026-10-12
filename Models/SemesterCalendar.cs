namespace cse325_group_project.Models;

// Generates the semester's class dates from a course's schedule, e.g. a
// 14-week course meeting Tuesdays & Thursdays that starts on a Monday
// begins Tuesday and yields 28 dates in chronological order.
public static class SemesterCalendar
{
    // Parses "Tuesday, Thursday" into DayOfWeek values; unknown entries are skipped.
    public static List<DayOfWeek> ParseDays(string scheduleDays) =>
        scheduleDays
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(day => Enum.TryParse<DayOfWeek>(day, out var dayOfWeek) ? dayOfWeek : (DayOfWeek?)null)
            .Where(day => day.HasValue)
            .Select(day => day!.Value)
            .ToList();

    // Every class date of the semester in order, anchored on the first meeting
    // day on/after startDate. Yields Weeks × SessionsPerWeek dates total.
    public static List<DateOnly> ClassDates(string scheduleDays, DateOnly startDate,
        int sessionsPerWeek, int weeks)
    {
        var dates = new List<DateOnly>();
        var days = ParseDays(scheduleDays);
        if (days.Count == 0 || startDate == default || sessionsPerWeek < 1 || weeks < 1)
        {
            return dates;
        }

        var totalClasses = weeks * sessionsPerWeek;
        var date = startDate;
        while (!days.Contains(date.DayOfWeek))
        {
            date = date.AddDays(1);
        }

        while (dates.Count < totalClasses)
        {
            if (days.Contains(date.DayOfWeek))
            {
                dates.Add(date);
            }
            date = date.AddDays(1);
        }

        return dates;
    }
}
