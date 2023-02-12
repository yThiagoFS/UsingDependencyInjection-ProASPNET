using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        public async Task Format(HttpContext context, string content)
        {
            context.Response.ContentType = "text/html";

            await context.Response.WriteAsync($@"
                        <!DOCTYPE html>
                        <html lang=""pt-br"">
                        <head>
                            <title>Response</title>
                        </head>
                        <body>
                            <h2>Formatted Response</h2>
                             <p>{content}</p>
                         </body>
                         </html>
                        ");
        }
    }
}
