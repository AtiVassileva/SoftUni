using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            var sb = new StringBuilder();
            var currentType = Type.GetType($"Stealer.{className}");

            var classInstance = Activator.CreateInstance(currentType, new object[] { });


            FieldInfo[] fieldsInClass = currentType.GetFields
            (BindingFlags.Static | BindingFlags.Instance |
             BindingFlags.Public | BindingFlags.NonPublic);

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fieldsInClass.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();
            var currentType = Type.GetType($"Stealer.{className}");

            var fields = currentType.GetFields(BindingFlags.Instance |
                                               BindingFlags.Public | BindingFlags.Static);

            var nonPublicMethods = currentType.GetMethods(BindingFlags.Static |
                                                          BindingFlags.NonPublic | BindingFlags.Instance);

            var publicMethods = currentType.GetMethods(BindingFlags.Static |
                                                       BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var nonPublicMethod in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }

            foreach (var publicMethod in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            var currentType = Type.GetType($"Stealer.{className}");

            var privateMethods = currentType.GetMethods
            (BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {currentType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            var currentType = Type.GetType($"Stealer.{className}");

            var methods = currentType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }

}
