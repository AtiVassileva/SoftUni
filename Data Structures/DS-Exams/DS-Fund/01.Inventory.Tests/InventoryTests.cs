using System;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using _01.Inventory.Models;
using _01.Inventory.Interfaces;
using System.Collections.Generic;

namespace _01.Inventory.Tests
{
    public class InventoryTests
    {
        private IHolder inventory;
        private IWeapon savedWeapon;

        [SetUp]
        public void SetupInventory()
        {
            this.inventory = new Inventory();
            ConstructorInfo[] constructors = new ConstructorInfo[]
            {
                this.GetConstructorInfo(typeof(Pistol)),
                this.GetConstructorInfo(typeof(Shotgun)),
                this.GetConstructorInfo(typeof(Minigun)),
                this.GetConstructorInfo(typeof(Sniper)),
                this.GetConstructorInfo(typeof(RocketLauncher)),
                this.GetConstructorInfo(typeof(Cannon)),
            };
            Random rnd = new Random();
            int boundIndex = rnd.Next(20);

            for (int i = 0; i < 20; i++)
            {
                var rndConstructor = constructors[rnd.Next(constructors.Length)];
                var rndAmmunition = rnd.Next(500);
                var rndMaxCapacity = rndAmmunition + rnd.Next(100);
                IWeapon rndWeapon = (IWeapon) rndConstructor
                    .Invoke(new object[] { i, rndMaxCapacity, rndAmmunition });
                if (i == boundIndex)
                {
                    this.savedWeapon = rndWeapon;
                }

                this.inventory.Add(rndWeapon);
            }
        }

        private ConstructorInfo GetConstructorInfo(Type eType)
        {
            return eType.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int) });
        }

        [Test]
        public void CapacityWorksCorrectly()
        {
            Assert.AreEqual(20, this.inventory.Capacity);
        }

        [Test]
        public void AddWorksCorrectly()
        {
            this.inventory.Add(new Sniper(21, 200, 50));
            Assert.AreEqual(21, this.inventory.Capacity);
        }

        [Test]
        public void GetByIdWorksCorrectly()
        {
            IWeapon weaponById = this.inventory.GetById(this.savedWeapon.Id);

            Assert.AreEqual(this.savedWeapon, weaponById);
        }


        [Test]
        public void ContainsFindsEntity()
        {
            Assert.IsTrue(this.inventory.Contains(this.savedWeapon));
        }


        [Test]
        public void RefillAmmunitionWorksCorrectly()
        {
            int ammoToRefill = this.savedWeapon.MaxCapacity - this.savedWeapon.Ammunition;
            int expectedAmmo = this.savedWeapon.MaxCapacity;

            this.inventory.Refill(this.savedWeapon, ammoToRefill);

            Assert.AreEqual(expectedAmmo, this.savedWeapon.Ammunition);
        }

        [Test]
        public void FireWorksCorrectly()
        {
            Random rnd = new Random();
            int ammoToFire = rnd.Next(this.savedWeapon.Ammunition);
            int expectedAmmo = this.savedWeapon.Ammunition - ammoToFire;

            bool isPossible = this.inventory.Fire(this.savedWeapon, ammoToFire);

            Assert.IsTrue(isPossible);
            Assert.AreEqual(expectedAmmo, this.savedWeapon.Ammunition);
        }

        [Test]
        public void RemoveByIdWorksCorrectly()
        {
            var expectedCapacity = 19;

            IWeapon removed = this.inventory.RemoveById(this.savedWeapon.Id);

            Assert.AreEqual(expectedCapacity, this.inventory.Capacity);
            Assert.AreEqual(this.savedWeapon, removed);
        }

        [Test]
        public void SwapWorksCorrectly()
        {
            IWeapon freshWeapon = null;

            switch (this.savedWeapon.Category)
            {
                case Category.Light:
                    freshWeapon = new Pistol(21, 500, 400);
                    break;
                case Category.Medium:
                    freshWeapon = new Minigun(21, 500, 500);
                    break;
                case Category.Heavy:
                    freshWeapon = new Cannon(21, 100, 80);
                    break;
                default:
                    break;
            }

            this.inventory.Add(freshWeapon);
            Assert.AreEqual(21, this.inventory.Capacity);

            var allWeapons = this.inventory.RetrieveAll();
            int firstIndex = allWeapons.IndexOf(this.savedWeapon);
            int secondIndex = allWeapons.IndexOf(freshWeapon);

            this.inventory.Swap(this.savedWeapon, freshWeapon);
            allWeapons = this.inventory.RetrieveAll();

            Assert.AreEqual(firstIndex, allWeapons.IndexOf(freshWeapon));
            Assert.AreEqual(secondIndex, allWeapons.IndexOf(this.savedWeapon));
        }

        [Test]
        public void RetrieveAllWorksCorrectly()
        {
            var allWeapons = this.inventory.RetrieveAll();

            Assert.AreEqual(20, allWeapons.Capacity);
        }

        [Test]
        public void ClearWorksCorrectly()
        {
            this.inventory.Clear();

            Assert.AreEqual(0, this.inventory.Capacity);
        }


        [Test]
        public void RetrieveInRangeWorksCorrectly()
        {
            this.inventory.Add(new Minigun(22, 200, 200));
            this.inventory.Add(new Cannon(23, 200, 200));

            List<IWeapon> weaponsInRange = this.inventory.RetrieveAll()
                .Where(w => (int)w.Category >= 1 && (int)w.Category <= 2)
                .OrderBy(w => w.Id)
                .ToList();

            List<IWeapon> actualWeapons = this.inventory
                .RetrieveInRange(Category.Medium, Category.Heavy)
                .OrderBy(w => w.Id)
                .ToList(); ;

            Assert.AreEqual(weaponsInRange.Capacity, actualWeapons.Capacity);

            for (int i = 0; i < weaponsInRange.Count; i++)
            {
                Assert.AreEqual(weaponsInRange[i], actualWeapons[i]);
            }
        }

        [Test]
        public void EmptyArsenalWorksCorrectly()
        {
            this.inventory.Add(new Pistol(21, 200, 200));

            this.inventory.EmptyArsenal(Category.Light);

            var allLightWeapons = this.inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Light);

            foreach (var weapon in allLightWeapons)
            {
                Assert.AreEqual(0, weapon.Ammunition);
            }
        }

        [Test]
        public void RemoveHeavyWorksCorrectly()
        {
            this.inventory.Add(new Cannon(21, 200, 200));
            int expectedCount = this.inventory.RetrieveAll()
                .Count(w => w.Category == Category.Heavy);

            int actualCount = this.inventory.RemoveHeavy();
            var allHeavyWeapons = this.inventory
                .RetrieveAll()
                .Where(w => w.Category == Category.Heavy);

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsEmpty(allHeavyWeapons);
        }

        [Test]
        public void EnumeratorWorksCorrectly()
        {
            int count = 0;
            foreach (var weapon in this.inventory)
            {
                count++;
            }

            Assert.AreEqual(20, count);
        }
    }
}