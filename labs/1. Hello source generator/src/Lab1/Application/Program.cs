using Application;
using System.Reflection;

var message = GetWelcomeMessage();
Console.WriteLine(message);

static string GetWelcomeMessage()
{
    string? message = null;

    // Try to find an implementation for IMessageProvider to show us a welcoming message.
    var messageProviderType = Assembly.GetExecutingAssembly().GetTypes()
        .FirstOrDefault(t => typeof(IMessageProvider).IsAssignableFrom(t) &&
                             !t.IsInterface &&
                             !t.IsAbstract);

    if (messageProviderType is not null)
    {
        var provider = Activator.CreateInstance(messageProviderType) as IMessageProvider;
        message = provider?.GetWelcomeMessage();
    }

    return message ?? "Hello?";
}