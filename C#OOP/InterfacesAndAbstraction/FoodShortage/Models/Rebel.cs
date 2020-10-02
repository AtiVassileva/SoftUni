using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer, IPerson
    {
        private int _foodAmount;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public int Food => this._foodAmount;
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }

        public void BuyFood()
        {
            this._foodAmount += 5;
        }

        
    }
}
