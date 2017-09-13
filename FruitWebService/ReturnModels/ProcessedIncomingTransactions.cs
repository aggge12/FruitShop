using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class ProcessedIncomingTransactions
    {
 
        public ProcessedIncomingTransactions()
        {
  
        }

        public ProcessedIncomingTransactions(int id, string Status, DateTime TimeProcessed, int Supplier)
        {
            this.id = id;
            this.Status = Status;
            this.TimeProcessed = TimeProcessed;
            this.Supplier = Supplier;
        }

        public int id { get; set; }

        public string Status { get; set; }

        public DateTime TimeProcessed { get; set; }

        public int Supplier { get; set; }



        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }

        public virtual Supplier Supplier1 { get; set; }*/
    }
}