using Telegram.Bot;
using Telegram.Bot.Types;

namespace StorySculpt.Telegram
{
    internal class Chat
    {
        readonly long id;

        readonly ITelegramBotClient telegramBotClient;

        private String _currentMessage;

        public Chat(Message message, ITelegramBotClient botClient)
        {
            id = message.Chat.Id;
            telegramBotClient = botClient;
            _currentMessage = message.Text;
        }

        public async void sendMessage(String message)
        {
            await telegramBotClient.SendTextMessageAsync(
                id,
                message
                );
        }

        public void setTextMessage(String text)
        {
            _currentMessage = text;
        }

        public String getCurrentMessage()
        {
            return _currentMessage;
        }
    }
}
