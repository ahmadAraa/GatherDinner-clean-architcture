namespace GatherDinner.Application;

public class DateTimeProvidor : IDateTimeProvidor
{
    public DateTime UtcNow => DateTime.UtcNow;
}