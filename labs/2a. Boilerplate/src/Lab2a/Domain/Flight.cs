using SourceGenerators;

namespace Domain;

[DeepClone]
public partial class Flight
{
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public Aircraft? Aircraft { get; set; }
}
