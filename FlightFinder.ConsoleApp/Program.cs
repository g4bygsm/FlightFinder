using FlightFinder.Core;

var service = new FlightSearchService([new MockFlightProvider(), new MockFlightProvider2()]);
var request = new SearchRequest("OTP", "LHR", DateOnly.FromDateTime(DateTime.Today.AddDays(30)));

Console.WriteLine($"Caut zboruri {request.Origin} -> {request.Destination}...\n");

var results = await service.SearchAllAsync(request);

foreach (var (provider, f) in results)
{
    Console.WriteLine($"{f.Airline,-10} {f.Departure:HH:mm}   {f.Price,4} {f.Currency}   ({provider})");
}

var best = results[0];
Console.WriteLine($"\nCel mai ieftin: {best.Flight.Airline} la {best.Flight.Price} {best.Flight.Currency} prin {best.Provider}");
Console.ReadKey();