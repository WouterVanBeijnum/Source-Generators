using Caching;

namespace Application.Messages
{
    public class MessageStore
    {
        private readonly Dictionary<Guid, string> _messages = [];

        public void UpsertMessage(Guid id, string message)
        {
            _messages[id] = message;
        }

        [Cache]
        public string GetMessage(Guid id)
        {
            if (_messages.TryGetValue(id, out var message))
            {
                return message;
            }
            throw new KeyNotFoundException($"Message with ID {id} not found.");
        }
    }
}


