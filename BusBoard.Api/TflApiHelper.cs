using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.Api
{
    public class TflApiHelper
    {
        private readonly RestClient client;

        public TflApiHelper()
        {
            client = new RestClient("https://api.tfl.gov.uk");
        }

        public IEnumerable<BusEntry> GetTopFiveBuses(string busStopCode)
        {
            var request = new RestRequest($"/StopPoint/{busStopCode}/Arrivals", Method.GET, DataFormat.Json);
            var response = client.Execute<List<BusEntry>>(request).Data;
            return response
                .OrderBy(bus => bus.expectedArrival)
                .Take(5);
        }

        public IEnumerable<StopPoint> GetStopPoints(Coordinate coordinate)
        {
            var request = new RestRequest("StopPoint", Method.GET, DataFormat.Json);
            request.AddParameter("stopTypes", "NaptanPublicBusCoachTram");
            request.AddParameter("radius", "800");
            request.AddParameter("modes","bus");
            request.AddParameter("lat", coordinate?.latitude ?? 0);
            request.AddParameter("lon", coordinate?.longitude ?? 0);
            return client.Execute<StopPointList>(request).Data.stopPoints ?? new List<StopPoint>();
        }
    }
}