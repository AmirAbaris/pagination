using api.DTOs;

namespace api.Interfaces;

public interface IPassengerRepository
{

    Task<Passenger?> RegisterAsync(PassengerInputDto passenger, CancellationToken cancellationToken);
    Task<List<Passenger>> GetAllAsync(CancellationToken cancellationToken);
}
