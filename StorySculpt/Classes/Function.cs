using System.Text.Json.Serialization;

namespace StorySculpt
{
    internal class Function
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("parameters")]
        public object? Parameters { get; set; }
    }
}
