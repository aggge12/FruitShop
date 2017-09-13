using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class Fruit
    {
        public Fruit()
        {
   
        }

        public Fruit(int id, string Name, int qtt)
        {
            this.id = id;
            this.Name = Name;
            this.QuantityInSupply = qtt;
        }

        public int id { get; set; }

        public string Name { get; set; }

        public int QuantityInSupply { get; set; }



        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FruitSupplier> FruitSupplier { get; set; }*/
    }
}