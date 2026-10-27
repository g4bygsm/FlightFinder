namespace FlightFinder.Core;

public interface IFlightProvider
{
	string Name { get; }
	Task<IReadOnlyList<Flight>> SearchAsync(SearchRequest request, CancellationToken ct = default);
}