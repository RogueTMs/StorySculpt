namespace StorySculpt.Classes
{
    internal class Location
    {
        public string name;

        private List<Model> npcs = new List<Model>();

        public Location(String name)
        {
            this.name = name;
        }

        public void AddModel(Model model)
        {
            npcs.Add(model);
        }

        public void RemoveModel(Model model) 
        {
            npcs.Remove(model);
        }

        public void NotifyAll(Message message) 
        {
            foreach (Model model in npcs) { model.AddEventMessage(message); }
        }

        public List<Model> GetModels() 
        {
            return npcs;
        }
    }
}
