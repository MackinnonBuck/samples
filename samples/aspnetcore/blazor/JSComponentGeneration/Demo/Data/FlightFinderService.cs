using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data;

public class FlightFinderService
{
	private static readonly Flight[] _departingFlights = new Flight[]
	{
		new(new(2021, 9, 10, 5, 0, 0), Airline.Southwest),
		new(new(2021, 9, 10, 13, 30, 0), Airline.Southwest),
		new(new(2021, 9, 10, 20, 15, 0), Airline.Delta),
		new(new(2021, 9, 11, 8, 45, 0), Airline.Delta),
		new(new(2021, 9, 12, 6, 0, 0), Airline.United),
		new(new(2021, 9, 13, 19, 30, 0), Airline.United),
		new(new(2021, 9, 13, 21, 00, 0), Airline.United),
		new(new(2021, 9, 14, 12, 30, 0), Airline.Spirit),
	};

	private static readonly Flight[] _returningFlights = new Flight[]
	{
		new(new(2021, 9, 17, 6, 15, 0), Airline.Spirit),
		new(new(2021, 9, 18, 14, 45, 0), Airline.Spirit),
		new(new(2021, 9, 18, 21, 30, 0), Airline.United),
		new(new(2021, 9, 19, 10, 0, 0), Airline.United),
		new(new(2021, 9, 20, 7, 15, 0), Airline.Delta),
		new(new(2021, 9, 21, 20, 45, 0), Airline.Delta),
		new(new(2021, 9, 21, 22, 15, 0), Airline.Delta),
		new(new(2021, 9, 22, 13, 45, 0), Airline.Southwest),
	};

	private static double SecondsBetweenTimes(TimeOnly t1, TimeOnly t2)
		=> t1 >= t2
		? (t1 - t2).TotalSeconds
		: (t2 - t1).TotalSeconds;

	public async Task<(Flight[], Flight[])> GetFlights(
		Airline[] airlines,
		DateOnly departureDate,
		DateOnly returnDate,
		TimeOnly preferredDepartureTime)
	{
		var departingFlights = _departingFlights
			.Where(flight => airlines.Contains(flight.Airline))
			.Where(flight => DateOnly.FromDateTime(flight.DepartureDateTime) == departureDate)
			.OrderBy(flight => SecondsBetweenTimes(TimeOnly.FromDateTime(flight.DepartureDateTime), preferredDepartureTime))
			.ToArray();

		var returningFlights = _returningFlights
			.Where(flight => airlines.Contains(flight.Airline))
			.Where(flight => DateOnly.FromDateTime(flight.DepartureDateTime) == returnDate)
			.OrderBy(flight => SecondsBetweenTimes(TimeOnly.FromDateTime(flight.DepartureDateTime), preferredDepartureTime))
			.ToArray();

		await Task.Delay(100);

		return (departingFlights, returningFlights);
	}
}
