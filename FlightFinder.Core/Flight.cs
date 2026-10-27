namespace FlightFinder.Core;

public record Flight(
    string Airline,
    string Origin,
    string Destination,
    DateTime Departure,
    DateTime Arrival,
    decimal Price,
    string Currency);