using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMaterialsNames = new[] { "shards", "motes", "fragments" };
            var keyMaterials = new Dictionary<string, long>();
            var junk = new Dictionary<string, long>();

            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            var itemObtained = string.Empty;
            var obtained = false;

            while (!obtained)
            {
                var inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (var i = 0; i < inputArr.Length; i += 2)
                {
                    var qty = long.Parse(inputArr[i]);
                    var material = inputArr[i + 1].ToLower();

                    if (keyMaterialsNames.Contains(material))
                    {
                        keyMaterials[material] += qty;

                        if (keyMaterials.Any(m => m.Value >= 250))
                        {
                            if (material == "shards")
                            {
                                itemObtained = "Shadowmourne";
                            }
                            else if (material == "fragments")
                            {
                                itemObtained = "Valanyr";
                            }
                            else
                            {
                                itemObtained = "Dragonwrath";
                            }

                            keyMaterials[material] -= 250;
                            obtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk[material] = 0;
                        }

                        junk[material] += qty;
                    }
                }
            }

            Console.WriteLine($"{itemObtained} obtained!");

            keyMaterials = keyMaterials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in keyMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            junk = junk.OrderBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}