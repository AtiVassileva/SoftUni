using System;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using _02.LegionSystem.Models;
using _02.LegionSystem.Interfaces;

namespace _02.LegionSystem.Tests
{
    public class LegionSystemTests
    {
        private IArmy legion;
        private IEnemy savedEnemy;
        private IEnemy fastestEnemy;
        private IEnemy slowestEnemy;

        [SetUp]
        public void SetupInventory()
        {
            this.legion = new Legion();
            ConstructorInfo[] constructors = new ConstructorInfo[]
            {
                this.GetConstructorInfo(typeof(Kamikaze)),
                this.GetConstructorInfo(typeof(Biomechanoid)),
                this.GetConstructorInfo(typeof(Kleer)),
                this.GetConstructorInfo(typeof(SirianWerebull)),
                this.GetConstructorInfo(typeof(Arachnoid)),
                this.GetConstructorInfo(typeof(Gnaar)),
            };
            Random rnd = new Random();
            int boundIndex = rnd.Next(20);
            int maxSpeed = int.MinValue;
            int minSpeed = int.MaxValue;

            for (int i = 0; i < 50; i++)
            {
                var rndConstructor = constructors[rnd.Next(constructors.Length)];
                var rndAttackSpeed = i + 10;
                var rndHealth = rnd.Next(1000);
                IEnemy rndEnemy = (IEnemy)rndConstructor
                    .Invoke(new object[] { rndAttackSpeed, rndHealth });
                if (i == boundIndex)
                {
                    this.savedEnemy = rndEnemy;
                }

                if (rndAttackSpeed > maxSpeed)
                {
                    maxSpeed = rndAttackSpeed;
                    this.fastestEnemy = rndEnemy;
                }

                if (rndAttackSpeed < minSpeed)
                {
                    minSpeed = rndAttackSpeed;
                    this.slowestEnemy = rndEnemy;
                }

                this.legion.Create(rndEnemy);
            }
        }

        private ConstructorInfo GetConstructorInfo(Type eType)
        {
            return eType.GetConstructor(new Type[] { typeof(int), typeof(int) });
        }

        [Test]
        public void TestCountWorksSuccessfuly()
        {
            Assert.AreEqual(50, this.legion.Size);
        }

        [Test]
        public void TestGetByAttackSpeedWorksSuccessfuly()
        {
            Assert.IsNotNull(this.legion.GetByAttackSpeed(this.savedEnemy.AttackSpeed));
        }

        [Test]
        public void TestContainsReturnsTrue()
        {
            var bio = new Biomechanoid(this.savedEnemy.AttackSpeed, 100);

            Assert.IsTrue(this.legion.Contains(bio));
        }

        [Test]
        public void TestGetFastestWorksSuccessfuly()
        {
            var fastestEnemy = this.legion.GetFastest();

            Assert.IsNotNull(fastestEnemy);
            Assert.AreEqual(this.fastestEnemy.AttackSpeed, fastestEnemy.AttackSpeed);
        }

        [Test]
        public void TestGetSlowestWorksSuccessfuly()
        {
            var slowestEnemy = this.legion.GetSlowest();

            Assert.IsNotNull(slowestEnemy);
            Assert.AreEqual(this.slowestEnemy.AttackSpeed, slowestEnemy.AttackSpeed);
        }

        [Test]
        public void TestShootFastestWorksSuccessfuly()
        {
            this.legion.ShootFastest();

            Assert.AreEqual(49, this.legion.Size);
            Assert.IsFalse(this.legion.Contains(this.fastestEnemy));
        }

        [Test]
        public void TestShootSlowestWorksSuccessfuly()
        {
            this.legion.ShootSlowest();

            Assert.AreEqual(49, this.legion.Size);
            Assert.IsFalse(this.legion.Contains(this.slowestEnemy));
        }

        [Test]
        public void TestGetOrderedByHealthDescendingWorksSuccessfuly()
        {
            var orderedByHealth = this.legion.GetOrderedByHealth();

            for (int i = 0; i < orderedByHealth.Length - 1; i++)
            {
                Assert.IsTrue(orderedByHealth[i].Health >= orderedByHealth[i + 1].Health);
            }
        }

        [Test]
        public void TestGetAllFasterThanGivenSpeedWorksSuccessfuly()
        {
            var legion = new Legion();

            for (int i = 0; i < 20; i++)
            {
                legion.Create(new Kamikaze(i, i * 2));
            }


            var fasterEnemies = legion.GetFaster(9);
            Assert.IsTrue(fasterEnemies.All(e => e.AttackSpeed > 9));
        }

        [Test]
        public void TestGetAllSlowerThanGivenSpeedWorksSuccessfuly()
        {
            var legion = new Legion();

            for (int i = 0; i < 20; i++)
            {
                legion.Create(new Kamikaze(i, i * 2));
            }


            var fasterEnemies = legion.GetSlower(9);
            Assert.IsTrue(fasterEnemies.All(e => e.AttackSpeed < 9));
        }
    }
}