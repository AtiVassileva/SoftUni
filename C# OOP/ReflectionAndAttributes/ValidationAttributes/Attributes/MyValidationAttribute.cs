using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]

    public abstract class MyValidationAttribute : Attribute
    {
        /// <summary>
        /// Accepts property and returns boolean depending
        /// on its validity
        /// </summary>
        
        public abstract bool IsValid(object obj);
    }
}
