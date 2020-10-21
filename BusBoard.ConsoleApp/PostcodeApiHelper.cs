using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class PostcodeApiHelper
    {
        private readonly RestClient client;

        public PostcodeApiHelper()
        {
            client = new RestClient("https://api.postcodes.io");
        }

        public Coordinate GetPostcodeCoordinates(string postcode)
        {
            var request = new RestRequest($"/postcodes/{postcode}", Method.GET);
            return client.Execute<Postcode>(request).Data.Result;
        }
    }
}
