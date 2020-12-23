using System;
using System.Linq;
using System.Collections.Generic;
using _02.LegionSystem.Interfaces;
using Wintellect.PowerCollections;

namespace _02.LegionSystem
{
    public class Legion : IArmy
    {
        private readonly OrderedSet<IEnemy> data;

        public Legion()
        {
            this.data = new OrderedSet<IEnemy>();
        }
        public int Size => this.data.Count;

        public bool Contains(IEnemy enemy)
        {
            return this.data.Contains(enemy);
        }

        public void Create(IEnemy enemy)
        {
            this.data.Add(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            return this.data.FirstOrDefault(e => e.AttackSpeed == speed);
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>();

            for (var i = 0; i < this.Size; i++)
            {
                var current = this.data[i];
                if (current.AttackSpeed > speed)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public IEnemy GetFastest()
        {
            this.CheckIfEmpty();
            return this.data.GetLast();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return this.data
                .OrderByDescending(x => x.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var result = new List<IEnemy>();

            for (var i = 0; i < this.Size; i++)
            {
                var current = this.data[i];
                if (current.AttackSpeed < speed)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public IEnemy GetSlowest()
        {
           this.CheckIfEmpty();
           return this.data.GetFirst();
        }

        public void ShootFastest()
        {
            this.CheckIfEmpty();
            this.data.RemoveLast();
        }

        public void ShootSlowest()
        {
            this.CheckIfEmpty();
            this.data.RemoveFirst();
        }
        private void CheckIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}