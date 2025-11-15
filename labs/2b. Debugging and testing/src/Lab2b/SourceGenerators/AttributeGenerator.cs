using Microsoft.CodeAnalysis;

namespace SourceGenerators;

[Generator]
internal class AttributeGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            ctx.AddSource("CacheAttribute.g.cs", """
                namespace Caching;

                [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
                internal class CacheAttribute : Attribute
                {
                }
                """);
        });
    }
}
