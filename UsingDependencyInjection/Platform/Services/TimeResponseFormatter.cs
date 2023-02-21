using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform.Services
{
    public class TimeResponseFormatter : IResponseFormatter
    {
        private ITimeStamper _stamper;

        public TimeResponseFormatter(ITimeStamper timeStamp)
        {
            _stamper = timeStamp;
        }

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"{_stamper.TimeStamp}: {content}");
        }
    }
}
