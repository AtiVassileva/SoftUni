using System.Linq;

namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RoyaleArena : IArena
    {
        private readonly Dictionary<int, BattleCard> data;

        public RoyaleArena()
        {
            this.data = new Dictionary<int, BattleCard>();
        }
        public void Add(BattleCard card)
        {
            this.data.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.data.ContainsValue(card);
        }

        public int Count => this.data.Count;

        public void ChangeCardType(int id, CardType type)
        {
            var card = this.data.Values.FirstOrDefault(c => c.Id == id);
            this.ValidateCard(card);
            card.Type = type;
        }

        public BattleCard GetById(int id)
        {
            var card = this.data.Values.FirstOrDefault(e => e.Id == id);
            this.ValidateCard(card);
            return card;
        }

        public void RemoveById(int id)
        {
            var card = this.data.Values.FirstOrDefault(e => e.Id == id);
            this.ValidateCard(card);
            this.data.Remove(card.Id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values)
            {
                if (card.Type == type)
                {
                    result.Add(card);
                }
            }

            this.ThrowExceptionIfNoSuchCards(result);
            return result.OrderByDescending(c => c.Damage).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values)
            {
                if (card.Type == type && card.Damage > lo && card.Damage < hi)
                {
                    result.Add(card);
                }
            }

            this.ThrowExceptionIfNoSuchCards(result);
            return result.OrderByDescending(c => c.Damage).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values)
            {
                if (card.Type == type && card.Damage <= damage)
                {
                    result.Add(card);
                }
            }

            this.ThrowExceptionIfNoSuchCards(result);
            return result.OrderByDescending(c => c.Damage).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values)
            {
                if (card.Name.Equals(name))
                {
                    result.Add(card);
                }
            }

            this.ThrowExceptionIfNoSuchCards(result);
            return result.OrderByDescending(c => c.Swag).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values)
            {
                if (card.Name.Equals(name) && card.Swag >= lo && card.Swag < hi)
                {
                    result.Add(card);
                }
            }

            this.ThrowExceptionIfNoSuchCards(result);
            return result.OrderByDescending(c => c.Swag).ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.data.Count)
            {
                throw new InvalidOperationException("Required cards cannot be more than the cards in the arena!");
            }

            var result = new List<BattleCard>();
            var ordered = new List<BattleCard>(this.data.Values.OrderBy(c => c.Swag).ThenBy(c => c.Id));

            for (var i = 0; i < n; i++)
            {
                result.Add(ordered[i]);
            }

            return result;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var result = new List<BattleCard>();

            foreach (var card in this.data.Values.OrderBy(c => c.Swag))
            {
                if (card.Swag >= lo && card.Swag <= hi)
                {
                    result.Add(card);
                }
            }

            return result;
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in this.data.Values)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateCard(BattleCard card)
        {
            if (card == null)
            {
                throw new InvalidOperationException("Card does not exist!");
            }
        }

        private void ThrowExceptionIfNoSuchCards(List<BattleCard> result)
        {
            if (result.Count == 0)
            {
                throw new InvalidOperationException("No such cards were found!");
            }
        }
    }
}