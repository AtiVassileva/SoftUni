using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.IO;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine
    {
        private readonly List<BaseHero> _heroes;
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public Engine(IReader reader, IWriter writer)
        {
            this._reader = reader;
            this._writer = writer;
            this._heroes = new List<BaseHero>();
        }

        public void Run()
        {
            var lines = int.Parse(this._reader.ReadLine());

            while (lines != 0)
            {
                var heroName = this._reader.ReadLine();
                var heroType = this._reader.ReadLine();
                
                try
                {
                    var currentHero = CreateHero(heroType, heroName);

                        this._heroes.Add(currentHero);
                        lines--;
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }

            }

            var bossPower = int.Parse(this._reader.ReadLine());

            foreach (var hero in this._heroes)
            {
                this._writer.WriteLine(hero.CastAbility());
            }

            var totalPower = CalculateTotalPower();

            this._writer.WriteLine(totalPower >= bossPower ? "Victory!" : "Defeat...");
        }

        private int CalculateTotalPower()
        {
            var totalPower = 0;
            if (this._heroes.Any())
            {
                totalPower = this._heroes.Sum(h => h.Power);
            }

            return totalPower;
        }

        private BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero hero;
            switch (heroType)
            {
                case "Paladin":
                    hero = new Paladin(heroName);
                    break;
                case "Druid":
                    hero = new Druid(heroName);
                    break;
                case "Rogue":
                    hero = new Rogue(heroName);
                    break;
                case "Warrior":
                    hero = new Warrior(heroName);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");

            }

            return hero;
        }
    }
}
