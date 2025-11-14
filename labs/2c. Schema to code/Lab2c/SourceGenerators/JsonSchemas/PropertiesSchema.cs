namespace SourceGenerators.JsonSchemas;

internal record PropertiesSchema
{
    public string? SchemaId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public bool Required { get; set; }
}