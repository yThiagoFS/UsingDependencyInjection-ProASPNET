using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate _next;


        public WeatherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IResponseFormatter formatter,
                                IResponseFormatter formatter2, IResponseFormatter formatter3)
        {
            if (context.Request.Path == "/middleware/class")
            {   await formatter.Format(context, string.Empty);
                await formatter2.Format(context, string.Empty);
                await formatter3.Format(context, string.Empty);
            }

            else
                await _next(context);
        }
    }
}
