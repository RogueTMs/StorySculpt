using System.Configuration;

namespace StorySculpt.Connection
{
    internal static class Client
    {
        static public HttpClient httpClient = new HttpClient();

        static private readonly string apiKey = ConfigurationManager.AppSettings["apiKey"];

        static public readonly string endpoint = "https://api.openai.com/v1/chat/completions";

        static Client()
        {
            httpClient.Timeout = new TimeSpan(0, 5, 0);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
    }
}
