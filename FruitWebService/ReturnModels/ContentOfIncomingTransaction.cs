using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class ContentOfIncomingTransaction
    {
        public int id { get; set; }

        public int Fruit { get; set; }

        public int Amount { get; set; }
        public int ProcessedIncomingTransactions { get; set; }

        public ContentOfIncomingTransaction(int id, int Fruit, int ProcessedIncomingTransactions, int Amount)
        {
            this.id = id;
            this.Fruit = Fruit;
            this.ProcessedIncomingTransactions = ProcessedIncomingTransactions;
            this.Amount = Amount;
        }

    }
}