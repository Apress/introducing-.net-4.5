using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialDataInEfExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var newYorkLocation = DbGeography.FromText("Point( -74.006605 40.714623)");
			var searchDistanceInMeters = 15000;

			using (var context = new AirTravelDbEntities1())
			{
				var airports = from a in context.Airports
							   where a.Location.Distance(newYorkLocation) < searchDistanceInMeters
							   select new { airportName = a.AirportName, 
                                              Code = a.AirportCode, 
                                              Distance = Math.Round(a.Location.Distance(newYorkLocation).Value/1000,2)
							  , b = a.Location};
				Console.WriteLine("SQL:");
				Console.WriteLine(airports.ToString());
				Console.WriteLine();

				Console.WriteLine("Aiports within {0} kilometres of New York:", searchDistanceInMeters / 1000);
				foreach (var airport in airports)
				{
					Console.WriteLine("{0} ({1}) {2} km", airport.airportName, airport.Code,airport.Distance);
				}

				Console.ReadKey();
			}
		}
	}
}
