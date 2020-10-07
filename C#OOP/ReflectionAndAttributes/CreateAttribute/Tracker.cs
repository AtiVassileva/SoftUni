using System;
using System.Linq;
using System.Reflection;

namespace CreateAttribute
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type.GetMethods(
                BindingFlags.Instance | BindingFlags.Static
                                      | BindingFlags.Public);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (SoftUniAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
