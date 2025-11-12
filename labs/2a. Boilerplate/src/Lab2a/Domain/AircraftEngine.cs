namespace Domain;

public class AircraftEngine
{
    public string Manufacturer { get; set; } = string.Empty;
    public int Power { get; set; }

    public AircraftEngine DeepClone()
    {
        return new AircraftEngine
        {
            Manufacturer = Manufacturer,
            Power = Power
        };
    }
}