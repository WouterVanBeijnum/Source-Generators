# Lab 2c: Schema to code

**Objective**: This exercise demonstrates how to transform external schema definitions into strongly-typed C# models using source generators with incremental generation pipelines.

## 1. Analyze the Existing Implementation

1. Open the provided solution and examine the `Messages` project structure.

2. Navigate to the `Messages/Schemas` directory. You'll find JSON schema files that define message types with their properties:
   - `Models` contains domain models used in the application.
   - `Operations` contains commands defining operations that can be performed on the models.
   - `Documentation` contains useful descriptions for all models and operations. The `ReferenceSchemaId` refers to the `SchemaId` of the model or operation it belongs to.

3. Review the `Program.cs` file to understand how the generated models will be consumed.

4. Currently, the application won't compile because the schema-based models haven't been generated yet.

## 2. Implement the Source Generator

### 2.1. Understanding the IncrementalSourceGenerator pipeline

The `IIncrementalGenerator` interface provides a more efficient and reliable approach to source generation compared to the older `ISourceGenerator` interface. The pipeline defines a series of operations on value providers to create new value providers. This is very similair to how LINQ creates a pipeline of operations on IEnumerables to create new IEnumerables. Key advantages include:

- Better performance through incremental computation
- Automatic caching and change detection
- Proper handling of file system dependencies
- More predictable and testable generation pipeline

Your task is to implement the `SchemaSourceGenerator` class that's already scaffolded in the `SourceGenerators` project.

### 2.2. Register additional files

Configure your source generator to detect JSON schema files. The incremental generator pipeline automatically handles change detection, but you should structure your code to take advantage of it:

1. Use `context.AdditionalTextsProvider` to access files defined in the `Schemas` directory.
2. Make sure to use one values provider for the `Documentation` directory and a second values provider for the `Models` and `Operations` directories.
3. Filter the additional files to include only `.json` files from the `Schemas` subdirectories.
4. Use the `.Select()` transformation to read the file content and path.

### 2.3. Parse schema files

Create a method to parse the JSON schema and extract the necessary information:

1. Define a simple schema model to represent the JSON structure or use the provided models in the `JsonSchemas` directory.
2. Update your values providers to parse the JSON content of the schemas. For convenience `System.Text.Json` has already been installed.
3. (Optional) Handle potential parsing errors gracefully.

### 2.4. Combining the value providers

In order to create the C# classes the class schemas and the documentation schemas should be joined:

1. Ensure all your values providers are providing individual schema definitions. For instance: `IncrementalValuesProvider<ClassSchema> classProvider`
2. Collect your documentation values provider.
3. Combine your model and operations provider with your documentation provider.

### 2.5. Generate C# Classes

Implement the code generation logic:

1. Register a source output node using `context.RegisterSourceOutput`.
2. Use the parsed schema information as input.
3. Generate C# class files with:
   - Appropriate namespace (`Domain` property in the schema)
   - Public accessibility
   - Auto-implemented properties matching the schema
   - XML summary documentation from schema descriptions (if present)

**Suggested method signature:**

```csharp
private static void GenerateClassFromSchema(SourceProductionContext context, (ClassSchema ClassSchema, ImmutableArray<DocumentationSchema> DocumentationSchema) source)
```

### 2.6. Validate the generator

1. Build the solution. The source generator should execute during compilation.
2. Verify that generated files appear in the project dependencies.
3. Run the application to ensure the generated classes work correctly.

## 3. Test Generator Resilience

Modify the schema files to verify the source generator's incremental capabilities:

1. **Add a new property** to an existing schema file and rebuild. Only that schema should regenerate.
2. **Create a new schema file** in the `Schemas` directory (e.g., `error-message.json`) and observe automatic code generation.
3. **Modify property types** in a schema and verify the generated code updates accordingly.
4. **Delete a schema file** and confirm the corresponding generated class is removed.

This demonstrates the power of incremental source generators: they automatically adapt to external file changes without manual intervention, while only regenerating what's necessary for optimal performance.

## 4. (Optional) Advanced challenges

If you complete the basic implementation, consider these enhancements:

1. **Root namespace**: Use the `CompilationProvider` to prefix the generated files' namespace with the root namespace of the application.
2. **Schema validation**: Add validation to ensure schema files follow the expected structure.
3. **Diagnostics**: Emit compiler warnings or errors for invalid schema files.

## Learning Outcomes

After completing this lab, you should understand:

- How to implement the `IIncrementalGenerator` interface for optimal performance
- How to process external files (AdditionalFiles) in a source generator
- How to set up proper incremental pipelines that respond to file changes
- Best practices for structuring incremental source generators
