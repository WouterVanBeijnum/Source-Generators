using SourceGenerators;

namespace Domain;

[DeepClone]
public partial class Aircraft
{
    public string Manufacturer { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Seats { get; set; }
    public int[] AisleSize { get; set; } = [];
    public ICollection<AircraftEngine> Engines { get; set; } = [];
}
