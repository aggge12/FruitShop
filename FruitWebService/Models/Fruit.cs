namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruit")]
    public partial class Fruit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fruit()
        {
            ContentOfIncomingTransaction = new HashSet<ContentOfIncomingTransaction>();
            ContentOfOutgoingTransaction = new HashSet<ContentOfOutgoingTransaction>();
            FruitSupplier = new HashSet<FruitSupplier>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int QuantityInSupply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FruitSupplier> FruitSupplier { get; set; }
    }
}
