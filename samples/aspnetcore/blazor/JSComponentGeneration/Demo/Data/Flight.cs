using System;

namespace Demo.Data;

public enum Airline
{
	Southwest,
	Delta,
	United,
	Spirit
}

public record Flight(DateTime DepartureDateTime, Airline Airline);
