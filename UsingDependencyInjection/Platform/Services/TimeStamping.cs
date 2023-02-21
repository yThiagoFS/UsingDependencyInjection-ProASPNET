namespace UsingDependencyInjection.Platform.Services
{
    public interface ITimeStamper
    {
        string TimeStamp { get; }
    }

    public class DefaultTimeStamper : ITimeStamper
    {
        public string TimeStamp { get => DateTime.Now.ToShortTimeString() }
    }
}
