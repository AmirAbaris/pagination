using api.DTOs;

namespace api.Controllers;

public class PassengerController(IPassengerRepository passengerRepository) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<Passenger>> Register(PassengerInputDto passengerIn, CancellationToken cancellationToken)
    {
        Passenger? passenger = await passengerRepository.RegisterAsync(passengerIn, cancellationToken);

        if (passenger is null)
            return BadRequest("something went wrong");

        return passenger;
    }

    [HttpGet("get-all/{pageNumber}")]
    public async Task<ActionResult<IEnumerable<Passenger>>> GetAll(int pageNumber, CancellationToken cancellationToken)
    {
        List<Passenger> passengers = await passengerRepository.GetAllAsync(pageNumber, cancellationToken);

        return passengers;
    }
}
