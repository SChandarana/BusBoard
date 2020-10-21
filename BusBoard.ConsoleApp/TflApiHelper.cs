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
            var request = new RestRequest($"/StopPoint/{busStopCode}/Arrivals", Method.GET, DataFormat.Json);
            return client.Execute<List<BusEntry>>(request).Data;
        }

        public IEnumerable<StopPoint> GetStopPoints(Coordinate coordinate)
        {
            var request = new RestRequest("StopPoint", Method.GET, DataFormat.Json);
            request.AddParameter("stopTypes", "NaptanPublicBusCoachTram");
            request.AddParameter("radius", "800");
            request.AddParameter("modes","bus");
            request.AddParameter("lat", coordinate.latitude);
            request.AddParameter("lon", coordinate.longitude);
            var response =  client.Execute<StopPointList>(request).Data;
            return response.stopPoints;
        }
    }
}