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
        public int id { get; set; }

        public int Fruit { get; set; }

        public int ProcessedIncomingTransactions { get; set; }

        public virtual Fruit Fruit1 { get; set; }

        public virtual ProcessedIncomingTransactions ProcessedIncomingTransactions1 { get; set; }
    }
}
