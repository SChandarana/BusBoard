using System.Collections.Generic;

namespace BusBoard.Api
{
    public class StopPoint
    {
        public string naptanId { get; set; }
    }

    class StopPointList
    {
        public List<StopPoint> stopPoints { get; set; }
    }
}
