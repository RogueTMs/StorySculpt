using StorySculpt.Connection;
using System.Net.Http.Json;

namespace StorySculpt.Classes
{
    internal class Model
    {
        private List<Message> messages = new List<Message>();


        public void AddSystemMessage(String message)
        {
            messages.Add(new Message()
            {
                Role = "system",
                Content = message
            });
        }

        public void AddEventMessage(Message message)
        {
            messages.Add(message);
        }

        public async Task<Message> GetMessage()
        {
            var requestData = new Request()
            {
                ModelId = "gpt-3.5-turbo",
                Messages = messages,
                Stream = false
            };
            using var response = await Client.httpClient.PostAsJsonAsync(Client.endpoint, requestData);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{(int)response.StatusCode} {response.StatusCode}");
            }

            ResponseData? responseData = new();

            responseData = await response.Content.ReadFromJsonAsync<ResponseData>();

            var choices = responseData?.Choices ?? new List<Choice>();
            if (choices.Count == 0)
            {
                throw new Exception("No choices");
            }
            var choice = choices[0];
            return choice.Message;
        }
    }
}
