using api.DTOs;

namespace api.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private const string _collectionName = "passengers";
    private readonly IMongoCollection<Passenger> _collection;

    // Dependency Injection
    public PassengerRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Passenger>(_collectionName);
    }

    public async Task<Passenger?> RegisterAsync(PassengerInputDto passengerIn, CancellationToken cancellationToken)
    {
        if (passengerIn is not null)
        {
            Passenger passenger = _Mappers.ConvertPassengerInputDtoToPassenger(passengerIn);

            await _collection.InsertOneAsync(passenger, null, cancellationToken);

            return passenger;
        }

        return null;
    }

    public async Task<List<Passenger>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Passenger> passengers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        return passengers;
    }
}
