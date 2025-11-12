namespace Domain;

public class Flight
{
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public Aircraft? Aircraft { get; set; }

    public Flight DeepClone()
    {
        return new Flight
        {
            DepartureAirport = DepartureAirport,
            ArrivalAirport = ArrivalAirport,
            DepartureTime = DepartureTime,
            ArrivalTime = ArrivalTime,
            Aircraft = Aircraft?.DeepClone(),
        };
    }
}
