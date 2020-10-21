namespace BusBoard.ConsoleApp
{
    public class Coordinate
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }

    public class Postcode
    {
        public Coordinate Result { get; set; }
    }
}
