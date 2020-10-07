using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        /// <summary>
        /// Check all object properties for custom attributes
        /// and if they are valid, the whole object is valid
        /// </summary>
        
        
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();

            var properties = type.GetProperties();

            // If all properties are valid with their custom
            // attributes -> Object is valid
            // If one property is not valid for one of
            // its custom attributes -> Object is not valid

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute).Cast<MyValidationAttribute>().ToArray();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
