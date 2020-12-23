namespace _02.DistrictManager
{
    public class Country 
    {
        public Country(int id, string name, int population) 
        {
            this.Id = id;
            this.Name = name;
            this.Population = population;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Country) obj;
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}