namespace FlightFinder.Core;

public class FlightSearchService
{
    private readonly IEnumerable<IFlightProvider> _providers;

    public FlightSearchService(IEnumerable<IFlightProvider> providers)
    {
        _providers = providers;
    }

    public async Task<IReadOnlyList<(string Provider, Flight Flight)>> SearchAllAsync(
        SearchRequest request, CancellationToken ct = default)
    {
        var tasks = _providers.Select(async p =>
        {
            try
            {
                var flights = await p.SearchAsync(request, ct);
                return flights.Select(f => (Provider: p.Name, Flight: f)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{p.Name}] a eșuat: {ex.Message}");
                return new List<(string Provider, Flight Flight)>();
            }
        });

        var results = await Task.WhenAll(tasks);

        return results
            .SelectMany(r => r)
            .OrderBy(r => r.Flight.Price)
            .ToList();
    }
}