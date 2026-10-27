namespace FlightFinder.Core;

public class MockFlightProvider2 : IFlightProvider
{
    private static readonly string[] Airlines = ["Wizz Air", "Ryanair", "Lufthansa", "Blue Air"];
    private readonly Random _random = new();

    public string Name => "Mock2";

    public async Task<IReadOnlyList<Flight>> SearchAsync(SearchRequest request, CancellationToken ct = default)
    {
        await Task.Delay(800, ct);

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