using UsingDependencyInjection.Models;
using UsingDependencyInjection.Platform;
using UsingDependencyInjection.Platform.Services;
using UsingDependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormatter,HtmlResponseFormatter>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

//IResponseFormatter formatter = new TextResponseFormatter();

app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    #region singleton
    //Forma utilizando Singleton (para poder "compartilhar" o mesmo servi�o pela aplica��o)
    //await TextResponseFormatter.Singleton.Format(context, "Middleware Function: It is snowing in Chicago");
    #endregion

    #region typebroker
    //Utilizando um TypeBroker (compartilha o servi�o atrav�s de uma interface)
    // pode ser tanto utilizado como o IResponseFormatter, quanto o HTMLResponseFormatter, alterando somente o TypeBroker
    //await TypeBroker.Formatter.Format(context, "Endpoint Function: It is snowing in Chicago");
    #endregion

    await formatter.Format(context, "Middleware Function: It is snowing in Chicago");

});

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

//Utilizando uma extens�o da interface IEndpointRouteBuilder -> que � usado para criar rotas na Program.cs
//app.MapWeather("endpoint/class");

//Utilizando tamb�m uma extens�o da interface, por�m, mais complexa, passando o tipo gen�rico da classe e resolvendo suas depend�ncias
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    #region singleton
    //Forma utilizando Singleton (para poder "compartilhar" o mesmo servi�o pela aplica��o)
    //await TextResponseFormatter.Singleton.Format(context, "Endpoint Function: It is sunny in LA");
    #endregion

    #region typebroker
    //Utilizando um TypeBroker (compartilha o servi�o atrav�s de uma interface)
    // pode ser tanto utilizado como o IResponseFormatter, quanto o HTMLResponseFormatter, alterando somente o TypeBroker
    //await TypeBroker.Formatter.Format(context, "Endpoint Function: It is sunny in LA");
    #endregion

    await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.MapGet("/", () => "Hello World");
app.Run();