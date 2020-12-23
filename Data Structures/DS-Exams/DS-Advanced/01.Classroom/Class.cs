namespace _01.Classroom
{
    public class Class
    {
        public Class(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Class)obj;
            return other.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}