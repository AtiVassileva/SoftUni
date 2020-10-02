using System;
using System.Collections.Generic;
using PlayersAndMonsters.Elfs;
using PlayersAndMonsters.Knights;
using PlayersAndMonsters.Wizards;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main()
        {
            var heroes = new List<Hero>()
            {
                new MuseElf("Gosho", 14),
                new BladeKnight("Arthur", 20),
                new DarkKnight("Batman", 90),
                new DarkWizard("Mike", 45),
                new SoulMaster("Pesho", 32)
            };

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero);
            }
        }
    }
}
