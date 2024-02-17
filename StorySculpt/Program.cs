using StorySculpt.Classes;
using StorySculpt.Telegram;


namespace StorySculpt
{
    internal class Program
    {   
        static private Location currLocation = new Location("Tavern");

        static void Main(string[] args)
        {
            Run();
            Thread.Sleep(Int32.MaxValue);
        }

        private static async void UserCommunication(Chat chat)
        {
            string content = chat.getCurrentMessage();
            if (content == null)
            {
                return;
            }
            currLocation.NotifyAll(new Message() { Role = "user", Content = content });
            List<Model> npcs = currLocation.GetModels();
            Random rnd = new Random();
            Model CurrModel = npcs[rnd.Next(0, npcs.Count)];
            Message responseMessage = await CurrModel.GetMessage();
            currLocation.NotifyAll(responseMessage);
            var responseText = responseMessage.Content.Trim();
            chat.sendMessage(responseText);
        }

        static async void Run()
        {
            Storyteller st = new Storyteller();
            Model model = await st.GenerateCharacter();
            currLocation.AddModel(model);

            var telegramBot = new TelegramBot();
            telegramBot.OnReceive += UserCommunication;
            telegramBot.Init();
        }

    }
}