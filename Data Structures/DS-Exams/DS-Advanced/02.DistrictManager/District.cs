namespace _02.DistrictManager
{
    public  class District 
    {
        public District(int id, string name, int sqMeters) 
        {
            this.Id = id;
            this.Name = name;
            this.SqMeters = sqMeters;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int SqMeters { get; set; }

        public override bool Equals(object obj)
        {
            var other = (District)obj;
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}