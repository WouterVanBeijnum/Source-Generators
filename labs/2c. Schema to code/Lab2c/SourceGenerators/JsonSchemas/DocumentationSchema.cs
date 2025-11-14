namespace SourceGenerators.JsonSchemas;

internal record DocumentationSchema
{
    public string? ReferenceSchemaId { get; set; }
    public string? Description { get; set; }
}
