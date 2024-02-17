using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorySculpt.Connection
{
    internal static class Client
    {
        static public HttpClient httpClient = new HttpClient();

        static private string apiKey = "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";

        static public string endpoint = "https://api.openai.com/v1/chat/completions";

        static Client()
        {
            httpClient.Timeout = new TimeSpan(0, 5, 0);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
    }
}
