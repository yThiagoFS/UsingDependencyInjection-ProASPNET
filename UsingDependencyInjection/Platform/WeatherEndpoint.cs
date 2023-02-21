﻿using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform
{
    public class WeatherEndpoint
    {
        //private IResponseFormatter _formatter;

        //public WeatherEndpoint(IResponseFormatter formatter)
        //{
        //    _formatter = formatter;
        //}

        public async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
