﻿using System;
using System.Collections.Generic;

namespace xchwallet
{
    public interface IAddress
    {
        string Tag { get; }
        string Path { get; }
        string Address { get; }
    }

    public interface ITransaction
    {
        string Id { get; }
        string From { get; }
        string To { get; }
        UInt64 Amount { get; }
        int Confirmations { get; }
    }

    public interface IWallet
    {
        bool IsMainnet();
        IAddress NewAddress(string tag);
        IEnumerable<ITransaction> GetTransactions(string address);
    }

    public class BaseAddress : IAddress
    {
        public string Tag { get; }
        public string Path { get; }
        public string Address { get; }

        public BaseAddress(string tag, string path, string address)
        {
            this.Tag = tag;
            this.Path = path;
            this.Address = address;
        }

        public override string ToString()
        {
            return $"'{Tag}' - {Path} - {Address}";
        }
    }

    public class BaseTransaction : ITransaction
    {
        public string Id { get; }
        public string From { get; }
        public string To { get; }
        public UInt64 Amount { get; }
        public int Confirmations { get; }

        public BaseTransaction(string id, string from, string to, UInt64 amount, int confirmations)
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Amount = amount;
            this.Confirmations = confirmations;
        }

        public override string ToString()
        {
            return $"<{Id} {From} {To} {Amount} {Confirmations}>";
        }
    }
}
