using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string fullName, int age)
        {
            this.FullFullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullFullName { get; set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; set; }
    }
}
