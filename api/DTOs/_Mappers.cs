namespace api.DTOs;

public static class _Mappers
{
    public static Passenger ConvertPassengerInputDtoToPassenger(PassengerInputDto passengerInputDto)
    {
        return new Passenger(
            Id: null,
            Name: passengerInputDto.Name.ToLower().Trim(),
            IdNumber: passengerInputDto.IdNumber
        );
    }
}
