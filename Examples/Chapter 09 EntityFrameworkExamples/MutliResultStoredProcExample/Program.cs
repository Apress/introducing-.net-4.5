using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiResultStoredProcExample
{
	class Program
	{
		static void Main(string[] args)
		{
			string distinationAirportCode = "NRT"; //Narita airport;
			using (var context = new AirTravelDbEntities1())
			{
				var result = context.AustralianAirportsAndDistances(distinationAirportCode);

				foreach (var ap in result)
				{
					Console.WriteLine("{0}: {1}, {2}", ap.AirportCode, ap.Latitude, ap.Longitude);
				}
				Console.WriteLine();
				//to get the second result we need to call GetNextResult()
				var result2 = result.GetNextResult<PointToPoint>();
				foreach (var ptp in result2)
				{
					Console.WriteLine("{0} -> {1}: {2} km", ptp.Origin, ptp.Destination, ptp.Distance);
				}
			}

			Console.ReadKey();
		}
	}
}
