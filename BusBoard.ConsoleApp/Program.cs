using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BusBoard.Api;

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
            var output = stopPoints
                .Take(2)
                .SelectMany(stop => tflApiHelper.GetTopFiveBuses(stop.naptanId));
            Console.WriteLine(
                string.Join("\n", output.Select(bus => bus.GetBusData())));
        }
    }
  }
}