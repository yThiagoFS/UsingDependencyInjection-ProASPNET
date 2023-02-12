using UsingDependencyInjection.Models;
using UsingDependencyInjection.Platform.Services;

namespace UsingDependencyInjection.Services
{
    public static class TypeBroker
    {
        private static IResponseFormatter formatter = new HtmlResponseFormatter();

        public static IResponseFormatter Formatter => formatter;
    }
}
