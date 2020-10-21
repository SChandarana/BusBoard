﻿using System;

namespace BusBoard.ConsoleApp
{
    public class BusEntry
    {
        public string stationName { get; set; }
        public string towards { get; set; }
        public DateTime expectedArrival { get; set; }

        public string GetBus()
        {
            return $"Bus towards: {towards} - Arriving to {stationName} at approximately {expectedArrival:HH:mm}";
        }
    }
}