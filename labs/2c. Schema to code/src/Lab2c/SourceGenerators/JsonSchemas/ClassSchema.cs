namespace SourceGenerators.JsonSchemas;

internal record ClassSchema
{
    public string? SchemaId { get; set; }
    public string? Type { get; set; }
    public string? Domain { get; set; }
    public PropertiesSchema[]? Properties { get; set; }
}
