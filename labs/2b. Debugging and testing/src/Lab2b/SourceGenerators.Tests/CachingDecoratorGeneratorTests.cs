using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace SourceGenerators.Tests;

[TestClass]
public sealed class CachingDecoratorGeneratorTests
{
    [TestMethod]
    public void With_BlockScoped_Namespace_Should_Generate_In_The_Same_Namespace()
    {
        // Arrange
        var source = """
            using Caching;

            namespace Testing.Namespace
            {
                public class MessageStore
                {
                    [Cache]
                    public string GetMessage(Guid id) => "Hello, World!";
                }
            }
            """;

        // Act
        var result = RunGenerator(source);

        // Assert
        Assert.HasCount(1, result);
        Assert.Contains("class MessageStoreCachingDecorator", result[0].SourceText.ToString());
        Assert.Contains("namespace Testing.Namespace", result[0].SourceText.ToString());
    }

    [TestMethod]
    public void With_FileScoped_Namespace_Should_Generate_In_The_Same_Namespace()
    {
        // Arrange
        var source = """
            using Caching;

            namespace Testing.Namespace;

            public class MessageStore
            {
                [Cache]
                public string GetMessage(Guid id) => "Hello, World!";
            }
            """;

        // Act
        var result = RunGenerator(source);

        // Assert
        Assert.HasCount(1, result);
        Assert.Contains("class MessageStoreCachingDecorator", result[0].SourceText.ToString());
        Assert.Contains("namespace Testing.Namespace", result[0].SourceText.ToString());
    }

    private static ImmutableArray<GeneratedSourceResult> RunGenerator(string source)
    {
        // TODO: Implement.
        return [];
    }
}
