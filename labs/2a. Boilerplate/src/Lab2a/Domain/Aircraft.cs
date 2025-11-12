using System.Text.Json;

namespace Domain;

public class Aircraft
{
    public string Manufacturer { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Seats { get; set; }
    public ICollection<AircraftEngine> Engines { get; set; } = [];

    public Aircraft DeepClone()
    {
        return JsonSerializer.Deserialize<Aircraft>(JsonSerializer.Serialize(this))!;
    }
}
