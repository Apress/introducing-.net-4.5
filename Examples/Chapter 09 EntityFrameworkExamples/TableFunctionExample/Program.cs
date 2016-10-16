using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableFunctionExample
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new AirTravelDbEntities())
			{
				var result = context.GetDistancesFromMajorAustralianAiports("NRT")
							.Where(a => a.StartPointAirportCode == "BNE" || a.StartPointAirportCode == "MEL");

				foreach (var item in result)
				{
					Console.WriteLine("{0} -> {1}: {2} km", item.StartPoint, item.EndPoint, item.Distance);
				}
				Console.ReadKey();
			}
		}
	}
}
