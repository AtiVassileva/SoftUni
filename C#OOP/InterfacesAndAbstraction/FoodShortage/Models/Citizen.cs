using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer, IPerson
    {
        private int _foodAmount;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this._foodAmount = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthday { get; }

        public int Food => this._foodAmount;

        public void BuyFood()
        {
            this._foodAmount += 10;
        }
    }
}
