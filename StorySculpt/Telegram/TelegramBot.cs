using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace StorySculpt.Telegram
{

    internal delegate void getMessage(Chat chat);

    internal class TelegramBot
    {

        public event getMessage OnRecive;


        private Dictionary<long, Chat> chats = new Dictionary<long, Chat>();

        // Это клиент для работы с Telegram Bot API, который позволяет отправлять сообщения, управлять ботом, подписываться на обновления и многое другое.
        private static ITelegramBotClient botClient;

        // Это объект с настройками работы бота. Здесь мы будем указывать, какие типы Update мы будем получать, Timeout бота и так далее.
        private static ReceiverOptions receiverOptions;

        public void Init()
        {

            botClient = new TelegramBotClient("6901438785:AAER8EprhrOr2eqD_Wo-Bqfx_r8keTKWUD0"); // Присваиваем нашей переменной значение, в параметре передаем Token, полученный от BotFather
            receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
            {
                AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов
                {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
            },
                // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
                // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
                ThrowPendingUpdates = true,
            };

            using var cts = new CancellationTokenSource();

            // UpdateHander - обработчик приходящих Update`ов
            // ErrorHandler - обработчик ошибок, связанных с Bot API
            var ErrorHandler = new ErrorHandler();
            botClient.StartReceiving(UpdateHandler, ErrorHandler.Run, receiverOptions, cts.Token); // Запускаем 
        }

        public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            var message = update.Message;

                            var chat = message.Chat;

                            chats[chat.Id] = new Chat(message, TelegramBot.botClient);

                            OnRecive?.Invoke(chats[chat.Id]);
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
