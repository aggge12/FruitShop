namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcessedOutgoingTransactions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcessedOutgoingTransactions()
        {
            ContentOfOutgoingTransaction = new HashSet<ContentOfOutgoingTransaction>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public DateTime? TimeProcessed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }
    }
}
