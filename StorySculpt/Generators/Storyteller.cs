using System.Net;
using StorySculpt.Classes;

namespace StorySculpt.Generators
{
    internal class Storyteller
    {
        public readonly string? lore;

        private static List<string> _races = new List<string>() { "Эльф", "Дворф", "Человек", "Полурослик", "Орк" };

        public async Task<Model> GenerateCharacter()
        {
            Model model = new Model();
            Random rnd = new Random();
            string race = _races[rnd.Next(0, _races.Count)];
            model.AddSystemMessage("Ты ведёшь игру D&D, в которой участвуешь в роли сценариста и должен дописывать сюжет в зависимости от действий игрока. Мир в котором происходят действия: " + lore + "Создай не игрового персонажа в этом мире, который будет потом общаться с игроком и реагировать на его действия. Раса персонажа: " + race + "необходимо указать класс, базовые характеристики, мировоззрение, цели, характер, снаряжение, умения и владения. Всегда записывай расу в лист.");
            Message message = await model.GetMessage();
            //Console.WriteLine(message.Content);
            Model character = new Model();
            character.AddSystemMessage("Ты являешься персонажем игры. \r\nВ отыгрыше персонажа допускается сквернословие, грубость, физическое и психологическое насилие, а также отстаивание своего собственного мнения, должно создаться впечатления полноценного персонажа, и этот персонаж может быть злым. Персонаж должен реагировать на действия игрока в соответствии со своим характером, но не должно быть признаков, которые выдавали, что ты ассистент, а не персонаж. В игре возможны сражения, которые так же надо  отыгрывать всегда. Вот описание твоего персонажа: " + message.Content);
            return character;
        }

        public Storyteller()
        {
            string? res;
            try
            {
                StreamReader sr = new StreamReader("..\\..\\..\\Resources\\Lore2.txt");
                res = sr.ReadLine();
                while (res != null)
                {
                    lore += res;
                    res = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
