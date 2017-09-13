using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class FruitSupplier
    {
        public int Fruit { get; set; }

        public int Supplier { get; set; }

        public int id { get; set; }

        public FruitSupplier(int id, int Fruit, int Supplier)
        {
            this.id = id;
            this.Fruit = Fruit;
            this.Supplier = Supplier;
        }

       /* public virtual Fruit Fruit1 { get; set; }

        public virtual Supplier Supplier1 { get; set; }*/
    }
}