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
    //Forma utilizando Singleton (para poder "compartilhar" o mesmo serviço pela aplicação)
    //await TextResponseFormatter.Singleton.Format(context, "Middleware Function: It is snowing in Chicago");
    #endregion

    #region typebroker
    //Utilizando um TypeBroker (compartilha o serviço através de uma interface)
    // pode ser tanto utilizado como o IResponseFormatter, quanto o HTMLResponseFormatter, alterando somente o TypeBroker
    //await TypeBroker.Formatter.Format(context, "Endpoint Function: It is snowing in Chicago");
    #endregion

    await formatter.Format(context, "Middleware Function: It is snowing in Chicago");

});

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

//Utilizando uma extensão da interface IEndpointRouteBuilder -> que é usado para criar rotas na Program.cs
//app.MapWeather("endpoint/class");

//Utilizando também uma extensão da interface, porém, mais complexa, passando o tipo genérico da classe e resolvendo suas dependências
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    #region singleton
    //Forma utilizando Singleton (para poder "compartilhar" o mesmo serviço pela aplicação)
    //await TextResponseFormatter.Singleton.Format(context, "Endpoint Function: It is sunny in LA");
    #endregion

    #region typebroker
    //Utilizando um TypeBroker (compartilha o serviço através de uma interface)
    // pode ser tanto utilizado como o IResponseFormatter, quanto o HTMLResponseFormatter, alterando somente o TypeBroker
    //await TypeBroker.Formatter.Format(context, "Endpoint Function: It is sunny in LA");
    #endregion

    await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.MapGet("/", () => "Hello World");
app.Run();