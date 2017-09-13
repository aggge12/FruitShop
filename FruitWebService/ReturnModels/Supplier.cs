using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class Supplier
    {
        
        public Supplier()
        {
           
        }

        public Supplier(int id, string Name)
        {
            this.id = id;
            this.Name = Name;
        }


        public int id { get; set; }

    
        public string Name { get; set; }

       /* [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FruitSupplier> FruitSupplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessedIncomingTransactions> ProcessedIncomingTransactions { get; set; }*/
    }
}