using System;
using System.Collections;
using _01.Inventory.Models;
using _01.Inventory.Interfaces;
using System.Collections.Generic;

namespace _01.Inventory
{
    public class Inventory : IHolder
    {
        private readonly List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon) => this.weapons.Add(weapon);

        public void Clear() => this.weapons.Clear();

        public bool Contains(IWeapon weapon)
        {
            for (var i = 0; i < this.Capacity; i++)
            {
                var current = this.weapons[i];
                if (current.Equals(weapon))
                {
                    return true;
                }
            }

            return false;
        }

        public void EmptyArsenal(Category category)
        {
            for (var i = 0; i < this.Capacity; i++)
            {
                var current = this.weapons[i];
                if (current.Category == category)
                {
                    current.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var current = this.GetById(weapon.Id);
            this.CheckIfExists(current);

            if (ammunition > current.Ammunition)
            {
                return false;
            }

            current.Ammunition -= ammunition;
            return true;
        }

        public IWeapon GetById(int id)
        {
            for (var i = 0; i < this.Capacity; i++)
            {
                var current = this.weapons[i];

                if (current.Id == id)
                {
                    return current;
                }
            }

            return null;
        }

        public IEnumerator GetEnumerator() => this.weapons.GetEnumerator();

        public int Refill(IWeapon weapon, int ammunition)
        {
            var current = this.GetById(weapon.Id);
            this.CheckIfExists(current);

            if (current.Ammunition + ammunition >= current.MaxCapacity)
            {
                current.Ammunition = current.MaxCapacity;
            }
            else
            {
                current.Ammunition += ammunition;
            }

            return current.Ammunition;
        }


        public IWeapon RemoveById(int id)
        {
            var weapon = this.GetById(id);
            this.CheckIfExists(weapon);
            this.weapons.Remove(weapon);
            return weapon;
        }

        public int RemoveHeavy() =>
            this.weapons
                .RemoveAll(w => w.Category == Category.Heavy);

        public List<IWeapon> RetrieveAll()
        {
            return this.Capacity == 0 ? new List<IWeapon>() : new List<IWeapon>(this.weapons);
        }

        public List<IWeapon> RetrieveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>();

            for (var i = 0; i < this.Capacity; i++)
            {
                var current = this.weapons[i];
                if (current.Category >= lower && current.Category <= upper)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var first = this.GetById(firstWeapon.Id);
            this.CheckIfExists(first);
            var second = this.GetById(secondWeapon.Id);
            this.CheckIfExists(second);

            if (first.Category == second.Category)
            {
                var firstIndex = weapons.IndexOf(first);
                var secondIndex = weapons.IndexOf(second);

                var temp = this.weapons[firstIndex];
                this.weapons[firstIndex] = this.weapons[secondIndex];
                this.weapons[secondIndex] = temp;
            }
        }

        private void CheckIfExists(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}