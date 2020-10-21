using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class TflApiHelper
    {
        private readonly RestClient client;

        public TflApiHelper()
        {
            client = new RestClient("https://api.tfl.gov.uk");
        }

        public IEnumerable<BusEntry> GetBuses(string busStopCode)
        {
            var request = new RestRequest($"/StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Execute<List<BusEntry>>(request).Data;
            return response.OrderBy(bus => bus.expectedArrival);
        }
    }
}