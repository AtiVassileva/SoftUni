using System;
using NUnit.Framework;
using System.Diagnostics;
using _02.LegionSystem.Models;
using _02.LegionSystem.Interfaces;

namespace _02.LegionSystem.PerformanceTests
{
    public class LegionSystemPerformanceTests
    {
        [Test]
        public void GetOrderedByHealth_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            legion.GetOrderedByHealth();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }
    }
}