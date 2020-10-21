using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        var tflApiHelper = new TflApiHelper();
        var postcodeApiHelper = new PostcodeApiHelper();

        while (true)
        {
            Console.WriteLine("Welcome to the BusBoard please enter a postcode you wish to check or 'exit' to exit");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("Thank you for using BusBoard");
                break;
            }

            var coordinate = postcodeApiHelper.GetPostcodeCoordinates(input);
            var stopPoints = tflApiHelper.GetStopPoints(coordinate);
            if (stopPoints == null)
            {
                Console.WriteLine("No nearby stops found for that postcode!");
            }

            else
            {
                var buses = new List<BusEntry>();
                foreach (var stopPoint in stopPoints.Take(2))
                {
                    buses.AddRange(tflApiHelper.GetBuses(stopPoint.naptanId));
                }
                var ordered = buses.OrderBy(bus => bus.expectedArrival);
                var topFive = ordered.Take(5).Select(bus => bus.GetBusData());
                Console.WriteLine(string.Join("\n", topFive));
            }
        }
    }
  }
}