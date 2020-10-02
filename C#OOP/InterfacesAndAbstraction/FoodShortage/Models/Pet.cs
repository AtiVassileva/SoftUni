using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; }
        public string Birthday { get; }
    }
}
