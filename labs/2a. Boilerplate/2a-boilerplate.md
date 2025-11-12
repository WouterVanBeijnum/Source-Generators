# Lab 2a: Eliminating Boilerplate

**Objective**: This exercise demonstrates how to replace repetitive boilerplate code with automated source generation using marker attributes.

## 1. Analyze the Existing Implementation

1. Open the provided solution and run the tests to establish a baseline.

2. Examine the `Domain` project models. Each model contains a `DeepClone` method that returns a complete copy of the object, including nested objects. The implementation ensures value equality while creating entirely new object references.

3. Review the various `DeepClone` implementations across different classes, noting their differences.

4. Once familiar with the implementations, delete all existing `DeepClone` methods to prepare for source generation.

## 2. Implement the Source Generator

### 2.1. Creating a generator

Add a new source generator to the `SourceGenerators` project and ensure the `Domain` project correctly references and recognizes the generator.

### 2.2. Create a marker attribute

To enable code generation, the source generator must identify target classes. While multiple approaches exist, this exercise uses attribute-based detection.

1. Create a `DeepCloneAttribute` class in your source generator project.
2. Apply this attribute to all classes in the `Domain` project that require the `DeepClone` method.

### 2.3. Locate marker attributes

Configure your source generator to detect classes decorated with the `DeepCloneAttribute`:

1. Use the `SyntaxProvider` to locate all occurrences of the `DeepCloneAttribute`.
2. Ensure the transform function returns the class symbols to which the attributes are applied.
3. Note that syntax provider methods return incremental value providers, which serve as inputs to the generation phase.

### 2.4. Generate method implementation

Implement the code generation logic:

1. Register a source output node in your source generator context.
2. Use the previously created value provider as input.
3. Create a private method to generate the `DeepClone` method for individual classes.
4. Implement the method and generate a correct `DeepClone` method.
5. Ensure the generated source is added to the compilation context.

Suggested method signature:

```csharp
private void GenerateDeepClonePartial(SourceProductionContext context, INamedTypeSymbol classSymbol)
```

### 2.5. Validate the generator

Run the test suite to verify your source generator's functionality. If certain edge cases prove challenging to implement, you might want to skip these and focus on the core functionality.

## 3. Test generator resilience

Modify the domain model to verify the source generator's incremental regeneration capabilities:

1. Add a new class with the `DeepCloneAttribute`.
2. Add or remove properties from existing classes.
3. Observe how the generated `DeepClone` methods automatically update to reflect domain changes.

This demonstrates the primary advantage of source generators: automatic adaptation to code changes without manual intervention.
