namespace HashTable
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int InitialCapacity = 16;

        private List<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public HashTable() : this(InitialCapacity)
        {
        }

        public HashTable(int capacity)
        {
            this.slots = new List<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (this.ContainsKey(key))
            {
                throw new ArgumentException("Key already exists!");
            }

            var item = new KeyValue<TKey, TValue>(key, value);
            this.AddItem(item);
            this.Count++;
            this.ResizeIfNeeded();
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            var item = this.Find(key);

            if (item != null)
            {
                item.Value = value;
            }
            else
            {
                this.Add(key, value);
            }
            return true;
        }

        public TValue Get(TKey key) => this.ValidateItem(key);

        public TValue this[TKey key]
        {
            get => this.ValidateItem(key);
            set => this.AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            var item = this.Find(key);

            if (item == null)
            {
                return false;
            }

            value = item.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var index = this.GetIndex(key);
            return this.slots[index]?.FirstOrDefault(it => it.Key.Equals(key));
        }

        public bool ContainsKey(TKey key) => this.Find(key) != null;

        public bool Remove(TKey key)
        {
            var item = this.Find(key);

            if (item == null)
            {
                return false;
            }
            var index = this.GetIndex(key);
            this.slots[index].Remove(item);
            this.slots[index] = this.slots[index].Count == 0 ? null : this.slots[index];
            this.Count--;
            return true;
        }

        public void Clear()
        {
            this.slots = new List<KeyValue<TKey, TValue>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.slots.Where(item => item != null)
                    .SelectMany(slot => slot.Select(item => item.Key));
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.slots.Where(item => item != null)
                    .SelectMany(slot => slot.Select(item => item.Value));
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot == null)
                {
                    continue;
                }

                foreach (var item in slot)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private TValue ValidateItem(TKey key)
        {
            var item = this.Find(key);

            if (item == null)
            {
                throw new KeyNotFoundException("No such key");
            }

            return item.Value;
        }

        private void AddItem(KeyValue<TKey, TValue> item)
        {
            var index = this.GetIndex(item.Key);

            if (this.slots[index] == null)
            {
                this.slots[index] = new List<KeyValue<TKey, TValue>>();
            }
            
            this.slots[index].Add(item);
        }

        private int GetIndex(TKey key)
        {
            var hash = key.GetHashCode();
            return Math.Abs(hash % this.Capacity);
        }

        private void ResizeIfNeeded()
        {
            if (this.Count / (double)this.Capacity < 0.75)
            {
                return;
            }

            var oldSlots = this.slots;
            this.slots = new List<KeyValue<TKey, TValue>>[this.Capacity * 2];

            foreach (var slot in oldSlots)
            {
                if (slot == null)
                {
                    continue;
                }

                foreach (var item in slot)
                {
                    this.AddItem(item);
                }
            }
        }
    }
}
