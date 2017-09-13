namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProcessedIncomingTransactions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcessedIncomingTransactions()
        {
            ContentOfIncomingTransaction = new HashSet<ContentOfIncomingTransaction>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime TimeProcessed { get; set; }

        public int Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }

        public virtual Supplier Supplier1 { get; set; }
    }
}
