namespace cse325_group_project.Models;

// Turns a course's meeting pattern into one display line, e.g.
// "Tuesdays & Thursdays 6:30–7:15 AM · 45 min twice a week · 14 weeks"
public static class ScheduleFormatting
{
    public static string Format(string scheduleDays, TimeOnly start, int sessionsPerWeek,
        int minutesPerSession, int weeks)
    {
        // Rows created before schedules existed (or bad data) get a friendly line.
        if (string.IsNullOrWhiteSpace(scheduleDays) || sessionsPerWeek is < 1 or > 2)
        {
            return "Schedule to be announced";
        }

        var days = scheduleDays
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(day => day + "s"); // "Tuesday" -> "Tuesdays"

        var end = start.AddMinutes(minutesPerSession);
        var startText = start.ToString("h:mm");
        var endText = end.ToString("h:mm tt");
        // "7:00–8:30 PM" when both times share AM/PM, else "11:30 AM–12:15 PM"
        var timeRange = start.ToString("tt") == end.ToString("tt")
            ? $"{startText}–{endText}"
            : $"{start:h:mm tt}–{endText}";

        var frequency = sessionsPerWeek == 1 ? "once a week" : "twice a week";

        return $"{string.Join(" & ", days)} {timeRange} · {minutesPerSession} min {frequency} · {weeks} weeks";
    }

    public static string Format(Course course) =>
        Format(course.ScheduleDays, course.StartTime, course.SessionsPerWeek,
            course.MinutesPerSession, course.Weeks);
}
