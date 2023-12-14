using api.DTOs;

namespace api.Controllers;


public class PassengerController(IPassengerRepository passengerRepository) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<Passenger>> Create(PassengerInputDto passengerIn, CancellationToken cancellationToken)
    {
        Passenger? passenger = await passengerRepository.RegisterAsync(passengerIn, cancellationToken);

        if (passenger is null)
            return BadRequest("something went wrong");

        return passenger;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<IEnumerable<Passenger>>> GetAll(CancellationToken cancellationToken)
    {
        List<Passenger> passengers = await passengerRepository.GetAllAsync(cancellationToken);

        return passengers;
    }
}
