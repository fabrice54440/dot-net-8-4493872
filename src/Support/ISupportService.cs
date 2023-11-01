namespace Support;

public interface ISupportService
{
  Task<Ticket[]> GetTicketsAsync();
}