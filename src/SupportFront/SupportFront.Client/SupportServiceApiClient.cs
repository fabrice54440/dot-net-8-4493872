using Support;
using System.Net.Http.Json;

namespace SupportFront.Client;

public class SupportServiceApiClient : ISupportService, IDisposable
{
  private readonly HttpClient http = new HttpClient();
  private readonly string ticketApi;

  public SupportServiceApiClient(IConfiguration conf)
  {
    this.ticketApi = conf.GetValue<string>("TicketApi")
      ?? "https://localhost/";
  }
  public void Dispose()
      => http.Dispose();

  public async Task<Ticket[]> GetTicketsAsync()
    => await http.GetFromJsonAsync<Ticket[]>($"{ticketApi}api/tickets")
       ?? Array.Empty<Ticket>();
}

