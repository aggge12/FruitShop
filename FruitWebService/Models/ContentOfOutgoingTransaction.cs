namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentOfOutgoingTransaction")]
    public partial class ContentOfOutgoingTransaction
    {
        public int id { get; set; }

        public int Fruit { get; set; }

        public int ProcessedOutgoingTransaction { get; set; }

        public virtual Fruit Fruit1 { get; set; }

        public virtual ProcessedOutgoingTransactions ProcessedOutgoingTransactions { get; set; }
    }
}
