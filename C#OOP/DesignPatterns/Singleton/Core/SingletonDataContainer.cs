using System;
using System.Collections.Generic;
using System.IO;
using Singleton.Contracts;

namespace Singleton.Core
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private readonly Dictionary<string, long> _capitals = 
            new Dictionary<string, long>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object...");

            var path = @"C:\Users\My PC\source\repos\DesignPatterns\SingletonDemo\Source\capitals.txt";
            var elements = File.ReadAllLines(path);

            for (var i = 0; i < elements.Length; i+= 2)
            {
                this._capitals.Add(elements[i], 
                    long.Parse(elements[i + 1]));
            }
        }
        public long GetPopulation(string name)
        {
            return this._capitals[name];
        }

        public static SingletonDataContainer Instance =>
        new SingletonDataContainer();
    }
}
