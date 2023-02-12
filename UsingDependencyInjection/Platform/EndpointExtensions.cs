using System.Reflection;
using UsingDependencyInjection.Services;

namespace UsingDependencyInjection.Platform
{
    public static class EndpointExtensions
    {
        // Extensão para o método de Endpoint da WeatherEndpoint
        //public static void MapWeather(this IEndpointRouteBuilder app, string path)
        //{
        //    IResponseFormatter formatter =
        //        app.ServiceProvider.GetRequiredService<IResponseFormatter>();

        //    app.MapGet(path, context => WeatherEndpoint.Endpoint(context, formatter));
        //}

        public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if(methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new Exception("Method cannot be used");
            }
            T endpointInstance =
                ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);
                                                         //passando para o método: context     -     instancia(formatter nesse caso)
            app.MapGet(path, (RequestDelegate)methodInfo.CreateDelegate(typeof(RequestDelegate), endpointInstance));
        }
        // Esse método de extensão aceita um tipo genérico de parametro que especifica a classe de endpoint que vai ser usada.
        // o outro argumento é o path que vai ser utilizado para criar a rota e o nome do metodo endpoint da classe que processará os requests
        // uma nova instancia do endpoint pé criada, e é utilizado um delegate  no metodo para criar a rota.


        #region ActivatorUtilies explicação
        /*
         Provê métodos para instanciar classes que possuem dependencias declaradas em seu construtor.
            Os métodos providos tornam mais fáceis a aplicação de Injeção de Dependência pra classes personalizadas.
         */
        #endregion
    }
}
