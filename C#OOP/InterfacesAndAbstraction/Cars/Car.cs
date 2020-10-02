namespace Cars
{
    public abstract class Car : ICar
    {

        protected Car(string color, string model)
        {
            this.Color = color;
            this.Model = model;
        }

        public string Model { get; }
        public string Color { get; }

        public string Start()
        {
            return "Breaaak!";
        }

        public string Stop()
        {
           return null;
        }


    }
}
