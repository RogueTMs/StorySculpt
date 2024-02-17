using StorySculpt.Classes;
using StorySculpt.Telegram;
using Telegram.Bot.Types;


namespace StorySculpt
{
    internal class Program
    {   
        static private Classes.Location currLocation = new Classes.Location("Tavern");

        static void Main(string[] args)
        {
            Storyteller st = new Storyteller();
            Model model = st.GenerateCharacter().Result;
            currLocation.AddModel(model);
            Run();
            Thread.Sleep(Int32.MaxValue);
        }

        private static async void UserCommunication(Telegram.Chat chat)
        {
            string content = chat.getCurrentMessage();
            if (content == null)
            {
                return;
            }
            currLocation.NotifyAll(new Classes.Message() { Role = "user", Content = content });
            List<Model> npcs = currLocation.GetModels();
            Random rnd = new Random();
            Model CurrModel = npcs[rnd.Next(0, npcs.Count)];
            Classes.Message responseMessage = await CurrModel.GetMessage();
            currLocation.NotifyAll(responseMessage);
            var responseText = responseMessage.Content.Trim();
            chat.sendMessage(responseText);
        }

        static async void Run()
        {
            // initialize Telegram bot
            var telegramBot = new TelegramBot();
            telegramBot.OnReceive += UserCommunication;
            telegramBot.Init();


            //Model model = new Model();
            //Location location = new Location("Tavern");
            //Storyteller st = new Storyteller();
            //Model model = await st.GenerateCharacter();
            ////Console.WriteLine(model.GetDescription());

            //location.AddModel(model);
            ////model.AddSystemMessage("Ты являешься персонажем игры. Вот твое описание: Имя персонажа: Элизабет \"Эли\" Старблейд\r\n\r\nОписание внешности: Элизабет высокая и стройная женщина с длинными, темно-русскими волосами, которые она всегда носит заплетенными в косу. У нее зеленые глаза, которые всегда кажутся готовыми к новым открытиям. На ее правой руке есть таинственная татуировка в форме магической руны.\r\n\r\nХарактер и личность: Элизабет обладает страстью к исследованиям и знанием, и она всегда готова рисковать, чтобы раскрывать тайны мира. Она обладает сильной волей и уверенностью, но также является сострадательной и готова помогать тем, кто в беде. Ей свойственна острая интуиция и любопытство.\r\n\r\nПрошлое персонажа: Элизабет родилась в семье известных археологов и исследователей древних артефактов. Она потеряла родителей в молодом возрасте в результате таинственного инцидента в старинном подземелье. Этот инцидент стал главным стимулом для ее приключений и поиска правды.\r\n\r\nОсновная цель в приключении: Элизабет стремится раскроить тайны древних артефактов и магии. Ее основная цель - найти ответы о прошлом своей семьи и разгадать магические загадки, которые преследуют ее с детства.\r\n\r\nСпособности и навыки: Элизабет владеет знаниями о древних языках, археологии и магии. Она отличается выдающейся ловкостью и навыками владения мечом. Ее магические способности включают в себя управление элементами и общение с духами.\r\n\r\nЧто мотивирует персонажа и его цели: Мотивацией Элизабет служит жажда знаний и желание найти истину о судьбе своей семьи. Она также стремится использовать свои способности, чтобы помочь другим, борясь с тьмой и злом в мире Эльдриса.");
            //while (true)
            //{
            //    // ввод сообщения пользователя
            //    Console.Write("User: ");
            //    var content = Console.ReadLine();
            //    if (content == null)
            //    {
            //        continue;
            //    }
            //    location.NotifyAll(new Message() { Role = "user", Content = content });
            //    List<Model> npcs = location.GetModels();
            //    Random rnd = new Random();
            //    Model CurrModel = npcs[rnd.Next(0, npcs.Count)];
            //    Message responseMessage = await CurrModel.GetMessage();
            //    location.NotifyAll(responseMessage);
            //    var responseText = responseMessage.Content.Trim();
            //    Console.WriteLine($"ChatGPT: {responseText}");
            //}

        }

    }
}