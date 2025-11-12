using SourceGenerators;

namespace Domain;

[DeepClone]
public partial class AircraftEngine
{
    public string Manufacturer { get; set; } = string.Empty;
    public int Power { get; set; }
}