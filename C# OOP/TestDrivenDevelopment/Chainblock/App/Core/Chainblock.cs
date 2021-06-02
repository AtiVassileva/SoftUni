using System;
using System.Linq;
using Chainblock.Enums;
using Chainblock.Common;
using System.Collections;
using Chainblock.Contracts;
using System.Collections.Generic;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;
        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;
        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.ExistingTransactionExceptionMessage);
            }
            this.transactions.Add(tx);
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException
                    (ExceptionMessages.NonExistingTransactionExceptionMessage);
            }

            var ts = this.transactions.First(t => t.Id == id);
            ts.Status = newStatus;

        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException(ExceptionMessages.NonExistingTransactionExceptionMessage);
            }

            var ts = this.transactions.First(t => t.Id == id);
            this.transactions.Remove(ts);
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NonExistingTransactionExceptionMessage);
            }

            var ts = this.transactions.First(t => t.Id == id);
            return ts;

        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(t => t.Status != status))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoMatchesWithThisStatusExceptionMessage);
            }

            var collection = this.transactions.
                    Where(t => t.Status == status).OrderByDescending(t => t.Amount);
            return collection;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(tx => tx.Status != status))
            {
                var message = string.Format(ExceptionMessages.NoPersonWithGivenStatusExceptionMessage, "sender");
                throw new InvalidOperationException(message);
            }

            return this.transactions.OrderBy(t => t.Amount).
                Where(t => t.Status == status).
                Select(ts => ts.From).ToList();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (this.transactions.All(tx => tx.Status != status))
            {
                var message = string.Format(ExceptionMessages.NoPersonWithGivenStatusExceptionMessage, "reciever");
                throw new InvalidOperationException(message);
            }

            return this.transactions.OrderBy(t => t.Amount).
                Where(t => t.Status == status).
                Select(ts => ts.To).ToList();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.Any()
                ? this.transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id)
                : throw new InvalidOperationException(ExceptionMessages.EmptyCollectionExceptionMessage);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (this.transactions.All(t => t.From != sender))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoTransactionsExceptionMessage);
            }

            var collection = this.transactions.OrderByDescending(t => t.Amount)
                .Where(t => t.From == sender).ToList();

            return collection;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (this.transactions.All(t => t.To != receiver))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoTransactionsExceptionMessage);
            }

            var collection = this.transactions.OrderBy(t => t.Amount)
                .ThenBy(t => t.Id)
                .Where(t => t.To == receiver).ToList();

            return collection;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            if (!this.transactions.Any(t => t.Status == status && t.Amount <= amount))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoTransactionsExceptionMessage);
            }

            var collection =
                this.transactions.Where(t => t.Status == status && t.Amount <= amount).
                    OrderByDescending(t => t.Amount).ToList();

            return collection;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!this.transactions.Any(t => t.From == sender && t.Amount > amount))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoTransactionsExceptionMessage);
            }

            var collection =
                this.transactions.Where(t => t.From == sender && t.Amount > amount).
                    OrderByDescending(t => t.Amount).ToList();

            return collection;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.transactions.Any(t => t.To == receiver && t.Amount >= lo && t.Amount <= hi))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NoTransactionsExceptionMessage);
            }

            var collection = this.transactions.Where(t =>
                    t.To == receiver && t.Amount >= lo && t.Amount <= hi)
                .OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            return collection;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            if (!this.transactions.Any(t => t.Amount >= lo && t.Amount <= hi))
            {
                return Enumerable.Empty<ITransaction>();
            }

            var collection = this.
                transactions.Where(t => t.Amount >= lo && t.Amount <= hi).ToList();

            return collection;
        }

        public IEnumerator<ITransaction> GetEnumerator()
            => this.transactions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}