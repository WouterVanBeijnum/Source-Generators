using Application.Messages;

var messageId = Guid.NewGuid();
var message1 = "This is my first message";
var message2 = "This is my second message";

var store = new MessageStore();
store.UpsertMessage(messageId, message1);
Console.WriteLine($"Who needs caching?: {store.GetMessage(messageId)}");
store.UpsertMessage(messageId, message2);
Console.WriteLine($"See? Works fine!: {store.GetMessage(messageId)}");

var cachedStore = new MessageStoreCachingDecorator(new MessageStore());
cachedStore.UpsertMessage(messageId, message1);
Console.WriteLine($"Getting from the cache also works fine!: {cachedStore.GetMessage(messageId)}");
cachedStore.UpsertMessage(messageId, message2);
Console.WriteLine($"Cache invalidation? What's that? Hmmmm, I see: {cachedStore.GetMessage(messageId)}");






