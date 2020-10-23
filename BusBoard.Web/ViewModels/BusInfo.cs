using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public IEnumerable<IEnumerable<BusEntry>> Stops { get; private set; }
        
        public BusInfo(IEnumerable<IEnumerable<BusEntry>> stops)
        {
            Stops = stops;
        }
    }
}