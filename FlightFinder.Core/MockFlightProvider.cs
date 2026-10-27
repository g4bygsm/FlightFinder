namespace FlightFinder.Core;

public class MockFlightProvider : IFlightProvider
{
    private static readonly string[] Airlines = ["Wizz Air", "Ryanair", "Lufthansa", "TAROM", "Austrian"];
    private readonly Random _random = new();

    public string Name => "Mock";

    public async Task<IReadOnlyList<Flight>> SearchAsync(SearchRequest request, CancellationToken ct = default)
    {
        await Task.Delay(500, ct);  

        return Airlines.Select(airline =>
        {
            var departure = request.Date.ToDateTime(new TimeOnly(_random.Next(5, 22), 0));
            return new Flight(
                airline, request.Origin, request.Destination,
                departure, departure.AddHours(_random.Next(1, 4)),
                _random.Next(40, 400), "EUR");
        }).ToList();
    }
}