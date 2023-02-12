﻿using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;
        public WeatherMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
                await _formatter.Format(context, "Middleware Class: It is raining in London");
            else
                await _next(context);
        }
    }
}
