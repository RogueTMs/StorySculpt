using StorySculpt.Classes;
using StorySculpt.TelegramImpl;


namespace StorySculpt
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            var telegramBot = new TelegramBot();
            telegramBot.Init();

            Thread.Sleep(Int32.MaxValue);
        }
    }
}