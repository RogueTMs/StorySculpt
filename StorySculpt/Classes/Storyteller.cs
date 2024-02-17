namespace StorySculpt.Classes
{
    internal class Storyteller
    {
        public readonly string? lore;

        public async Task<Model> GenerateCharacter() 
        {
            Model model = new Model();
            model.AddSystemMessage("Ты ведёшь игру D&D, в которой участвуешь в роли сценариста и должен дописывать сюжет в зависимости от действий игрока. Мир в котором происходят действия: " + lore + "Создай не игрового персонажа в этом мире, который будет потом общаться с игроком и реагировать на его действия, для этого необходимо указать расу, класс, базовые характеристики, мировоззрение, цели, характер, снаряжение, умения и владения (возможные расы: эльфы, дворфы, гномы, орки, людоящеры, полурослики, гоблины, люди, тифлинги, чейнджлинги)");
            Message message = await model.GetMessage();
            Console.WriteLine(message.Content);
            Model character = new Model();
            character.AddSystemMessage("Ты являешься персонажем игры. Вот твое описание: " + message.Content);
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
