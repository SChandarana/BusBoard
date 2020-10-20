using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using RestSharp.Serialization.Json;

namespace BusBoard.ConsoleApp
{
    class Helpers
    {
        public static List<BusEntry> GetBuses(string busStopCode, RestClient client)
        {

            var request = new RestRequest($"/StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Execute<List<BusEntry>>(request);
            var items = response.Data;
            var sortedItems = items.OrderBy(o => o.expectedArrival).ToList();
            return sortedItems;
        }
    }
}


