namespace FlightFinder.Core;

public record SearchRequest(string Origin, string Destination, DateOnly Date);