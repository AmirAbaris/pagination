namespace api.Repositories;

public class PassengerRepository
{
    private const string _collectionName = "passengers";
    private readonly IMongoCollection<Passenger> _collection;

    // Dependency Injection
    public PassengerRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Passenger>(_collectionName);
    }

    public async Task<Passenger?> RegisterAsync(Passenger passengerIn, CancellationToken cancellationToken)
    {
        if (passengerIn is not null)
        {
            Passenger passenger = new(
                Id: null,
                Name: passengerIn.Name.ToLower().Trim(),
                IdNumber: passengerIn.IdNumber
            );

            await _collection.InsertOneAsync(passenger, null, cancellationToken);
        }

        return null;
    }

    public async Task<List<Passenger>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Passenger> passengers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        return passengers;
    }
}
