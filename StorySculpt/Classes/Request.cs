using StorySculpt.Classes;
using System.Text.Json.Serialization;

namespace StorySculpt
{
    internal class Request
    {
        [JsonPropertyName("model")]
        public string ModelId { get; set; } = "gpt-3.5-turbo";
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; } = new();
        //[JsonPropertyName("functions")]
        //public List<Function> Functions { get; set; } = new();
        [JsonPropertyName("stream")]

        public bool Stream { get; set; } = false;
    }
}
