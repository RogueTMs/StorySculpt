using Telegram.Bot;
using Telegram.Bot.Types;

namespace StorySculpt.TelegramImpl
{

    public delegate void getMessage();

    //public delegate void sendMessage(Chat chat, String msg);

    public class Chat
    {

        public event getMessage OnReceive;

        //public event sendMessage sendMessage;

        readonly long id;

        readonly ITelegramBotClient telegramBotClient;

        private String _currentMessage;

        private Session _currentSession = null;

        public Chat(Message message, ITelegramBotClient botClient)
        {
            id = message.Chat.Id;
            telegramBotClient = botClient;
            
            setTextMessage(message.Text);

        } 

        public async void printMessage(String message)
        {
            await telegramBotClient.SendTextMessageAsync(
                id,
                message
                );
        }

        public void setTextMessage(String text)
        {
            _currentMessage = text;

            if (_currentMessage == "/start")
            {
                _currentSession = new Session(this);
                _currentSession.Run();
                printMessage($"Игра началась! Ваш чат Id: {id}");
                //sendMessage?.Invoke(chats[chat.Id], "Игра началась!");
            }
            else
            {
                
                OnReceive?.Invoke();
            }
        }

        public String getCurrentMessage()
        {
            return _currentMessage;
        }
    }
}
