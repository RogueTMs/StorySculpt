using StorySculpt.Generators;
using StorySculpt.TelegramImpl;
using Telegram.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorySculpt.Classes;

namespace StorySculpt
{

    internal class Session
    {

        private Location currLocation = new Location("Tavern");

        private Chat chat;

        Model CurrModel;

        public Session(Chat chat) {
            this.chat = chat;
        }


        private async void UserCommunication()
        {
            string content = chat.getCurrentMessage();
            if (content == null)
            {
                return;
            }
            currLocation.NotifyAll(new Message() { Role = "user", Content = content });

            Message responseMessage = await CurrModel.GetMessage();
            currLocation.NotifyAll(responseMessage);
            String responseText = responseMessage.Content.Trim();

            chat.printMessage(responseText);
        }

        public async void Run()
        {
            Storyteller st = new Storyteller();
            Model model = await st.GenerateCharacter();
            currLocation.AddModel(model);

            List<Model> npcs = currLocation.GetModels();
            Random rnd = new Random();
            CurrModel = npcs[rnd.Next(0, npcs.Count)];

            chat.OnReceive += UserCommunication;
        }


    }
}
