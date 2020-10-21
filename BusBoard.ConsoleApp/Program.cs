using System;
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
        while (true)
        {
            Console.WriteLine("Welcome to the BusBoard please enter the bus stop code you wish to check or exit to exit");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("Thank you for using BusBoard");
                break;
            }
            var buses = tflApiHelper.GetBuses(input);
            var topFive = buses.Take(5).Select(bus => bus.GetBusData());
            Console.WriteLine(string.Join("\n", topFive));
        }
    }
  }
}