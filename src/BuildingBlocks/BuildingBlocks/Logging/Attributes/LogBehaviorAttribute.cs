namespace BuildingBlocks.Logging.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class LogBehaviorAttribute : Attribute
{
    public Enums.LoggingType logType { get; }

    public LogBehaviorAttribute(Enums.LoggingType logType)
    {
        this.logType = logType;
    }
}