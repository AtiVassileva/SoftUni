namespace WildFarm.Models
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        
        public string Name { get; protected set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract double WeightMultiplier { get; protected set; }
        public abstract string Eat(Food food);
    }
}
