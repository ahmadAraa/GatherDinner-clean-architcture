namespace GatherDinner.Application;

public interface IDateTimeProvidor
{
    DateTime UtcNow { get; }
}