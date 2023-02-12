using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Models
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        //Utilização de um Singleton (utilizado antes de ter a injeção de dependência)
        private static TextResponseFormatter? shared;

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Response {++responseCounter}:\n {content}");
        }

        public static TextResponseFormatter Singleton {
            get
            {
                if (shared == null)
                {
                    shared = new TextResponseFormatter();
                }
                return shared;
            }
        }
    }
}
