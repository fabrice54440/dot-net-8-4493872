using System.Text.Json.Serialization;
using Support;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var tickets = new Ticket[] {
    new(Guid.Parse("{CECE3AFB-85B4-427D-8A36-81CD5764C4A8}"), "Plantage", "...", "alice@dotnet.example", DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2), Ticket.Etat.Ferme),
    new(Guid.Parse("{E9AD7E7F-AA59-4937-9A8C-95273A2A98C9}"), "Bouton grisé", "...", "bob@dotnet.example", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2), Ticket.Etat.EnAttente),
    new(Guid.Parse("{63C98517-0CD1-48AA-A96C-B252E21DFD5C}"), "Message d'erreur #432", "...", "alice@dotnet.example", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-2), Ticket.Etat.Ouvert),
};
var ticketsParId = tickets.ToDictionary(t => t.Id);

var todosApi = app.MapGroup("/api/tickets");
todosApi.MapGet("/", () => tickets);
todosApi.MapGet("/{id}", (Guid id) =>
    ticketsParId.ContainsKey(id)
        ? Results.Ok(ticketsParId[id])
        : Results.NotFound());

app.Run();

[JsonSerializable(typeof(Ticket[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
