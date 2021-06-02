using System;
using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Enums;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string sender;
        private string reciever;
        private double amount;

        public Transaction(int id, TransactionStatus status, string sender, string reciever, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = sender;
            this.To = reciever;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidIdExceptionMessage);
                }

                this.id = value;
            }
        }
        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this.sender;
            set
            {
                this.CheckForInvalidName(value, "sender");
                this.sender = value;
            }
        }

        public string To
        {
            get => this.reciever;
            set
            {
                this.CheckForInvalidName(value, "reciever");
                this.reciever = value;
            }
        }

        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.ZeroOrNegativeAmountExceptionMessage);
                }

                this.amount = value;
            }
        }

        private void CheckForInvalidName(string value, string label)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var message = string.Format
                    (ExceptionMessages.NullOrWhiteSpaceNameExceptionMessage, label);
                throw new ArgumentNullException(message);
            }

            if (value.Length < 3)
            {
                var message = string.Format
                    (ExceptionMessages.LessThanThreeSymbolsNameExceptionMessage, label);
                throw new ArgumentException();
            }
        }
    }
}