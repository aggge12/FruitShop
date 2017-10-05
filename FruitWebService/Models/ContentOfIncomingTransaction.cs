namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentOfIncomingTransaction")]
    public partial class ContentOfIncomingTransaction
    {
        public ContentOfIncomingTransaction()
        {

        }

        public ContentOfIncomingTransaction(int Fruit, int ProcessedIncomingTransactions, int Amount)
        {
            this.Fruit = Fruit;
            this.ProcessedIncomingTransactions = ProcessedIncomingTransactions;
            this.Amount = Amount;
        }
        public int id { get; set; }

        public int Fruit { get; set; }

        public int ProcessedIncomingTransactions { get; set; }

        public int? Amount { get; set; }

        public virtual Fruit Fruit1 { get; set; }

        public virtual ProcessedIncomingTransactions ProcessedIncomingTransactions1 { get; set; }
    }
}
