namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            FruitSupplier = new HashSet<FruitSupplier>();
            ProcessedIncomingTransactions = new HashSet<ProcessedIncomingTransactions>();
        }

        public Supplier(string Name)
        {
            FruitSupplier = new HashSet<FruitSupplier>();
            ProcessedIncomingTransactions = new HashSet<ProcessedIncomingTransactions>();
            this.Name = Name;
        }

        public Supplier(int id,string Name)
        {
            FruitSupplier = new HashSet<FruitSupplier>();
            ProcessedIncomingTransactions = new HashSet<ProcessedIncomingTransactions>();
            this.Name = Name;
            this.id = id;
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FruitSupplier> FruitSupplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessedIncomingTransactions> ProcessedIncomingTransactions { get; set; }
    }
}
