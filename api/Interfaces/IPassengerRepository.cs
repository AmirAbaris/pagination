namespace api.Interfaces;

public interface IPassengerRepository
{

    Task<Passenger?> RegisterAsync(Passenger passenger, CancellationToken cancellationToken);
    Task<List<Passenger>> GetAllAsync(CancellationToken cancellationToken);
}
